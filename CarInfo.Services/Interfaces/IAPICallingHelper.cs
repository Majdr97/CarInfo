namespace CarInfo.Services.Interfaces;

using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using CarInfo.Services.Entities;

public interface IAPICallingHelper
{
    Task<APIResponse> GetAPI(LogLevel logLevel, string serviceName, string url, Dictionary<string, string>? headers = null);
    Task<APIResponse> PostAPI(LogLevel logLevel, string serviceName, string url, dynamic? request, Dictionary<string, string>? headers = null, bool serializeRequest = true);
}