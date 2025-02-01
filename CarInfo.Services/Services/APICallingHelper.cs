namespace CarInfo.Services.Services;

using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using Microsoft.Extensions.Logging;

using CarInfo.Services.Entities;
using CarInfo.Services.Interfaces;

public class APICallingHelper(ILog log) : IAPICallingHelper
{
    #region Members

    private readonly ILog _log = log;

    #endregion

    public async Task<APIResponse> GetAPI(LogLevel logLevel, string serviceName, string url, Dictionary<string, string>? headers = null)
    {
        return await CallAPI(HttpMethod.Get, logLevel, serviceName, url, null, headers, false);
    }

    public async Task<APIResponse> PostAPI(LogLevel logLevel, string serviceName, string url, dynamic? request, Dictionary<string, string>? headers = null, bool serializeRequest = true)
    {
        return await CallAPI(HttpMethod.Post, logLevel, serviceName, url, request, headers, serializeRequest);
    }

    #region Private Methods

    private async Task<APIResponse> CallAPI(HttpMethod method, LogLevel logLevel, string serviceName, string url, dynamic? request, Dictionary<string, string>? headers, bool serializeRequest = true)
    {
        try
        {
            string? serializedRequest = request != null && serializeRequest ? JsonConvert.SerializeObject(request) : request;

            using var httpClient = CreateHttpClient(headers);

            HttpRequestMessage message = new(method, url);
            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                message.Content = serializedRequest != null ? new StringContent(serializedRequest, Encoding.UTF8, Constants.JSONContentType) : null;
            }

            var httpResponse = await httpClient.SendAsync(message);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var apiResponse = new APIResponse(httpResponse.IsSuccessStatusCode, responseContent, httpResponse.StatusCode, MapErrorCode(httpResponse.StatusCode));

            _log.Log(logLevel, JsonConvert.SerializeObject(new
            {
                ServiceName = serviceName,
                URL = url,
                Request = serializedRequest,
                apiResponse.Response,
                Headers = JsonConvert.SerializeObject(headers)
            }));

            return apiResponse;
        }
        catch (Exception ex)
        {
            _log.Log(LogLevel.Error, $"Error while calling API: {url}", ex);
            return new APIResponse(false, ex.Message, HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }
    private HttpClient CreateHttpClient(Dictionary<string, string>? headers)
    {
        var client = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });

        if (headers != null)
        {
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        return client;
    }
    private string MapErrorCode(HttpStatusCode status) => status switch
    {
        HttpStatusCode.OK => string.Empty,
        HttpStatusCode.Created => string.Empty,
        HttpStatusCode.Unauthorized => "Unauthorized",
        HttpStatusCode.NotFound => "API URL Not Found",
        HttpStatusCode.BadRequest => "Bad Request",
        HttpStatusCode.GatewayTimeout => "Time Out",
        HttpStatusCode.RequestTimeout => "Time Out",
        _ => "Internal Server Error"
    };

    #endregion
}