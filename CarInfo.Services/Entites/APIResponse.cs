namespace CarInfo.Services.Entities;

using System.Net;

public class APIResponse(bool success = false, string? response = null, HttpStatusCode httpStatus = HttpStatusCode.OK, string? error = null)
{
    public string? Response { get; set; } = response;
    public HttpStatusCode StatusCode { get; set; } = httpStatus;
    public bool Success { get; set; } = success;
    public string? ErrorMessage { get; set; } = error;
}