namespace CarInfo.Services.Services;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using CarInfo.Services.Entites;
using CarInfo.Services.Interfaces;
using CarInfo.Services.Extensions;

public class CarService(IAPICallingHelper apiCallingHelper, IConfiguration configuration) : ICarService
{
    private readonly IAPICallingHelper _APICallingHelper = apiCallingHelper;
    private readonly IConfiguration _Configuration = configuration;

    public async Task<CarMakeResponse?> GetAllMakesAsync()
    {
        var url = _Configuration.GetSection("APIsSettings:GetAllMakesUrl").Value!;
        var apiResult = await _APICallingHelper.GetAPI(LogLevel.Information, Constants.ServicesNames.GetAllMakes, url);

        if (apiResult.Success)
        {
            if (apiResult.Response!.TryParseJson<CarMakeResponse>(out var result))
            {
                return result;
            }
        }

        return null;
    }
    public async Task<VehicleTypeResponse?> GetVehicleTypesForMakeAsync(int makeId)
    {
        var url = _Configuration.GetSection("APIsSettings:GetVehicleTypeUrl").Value!.Replace("{makeId}", makeId.ToString());
        var apiResult = await _APICallingHelper.GetAPI(LogLevel.Information, Constants.ServicesNames.GetVehicleType, url);

        if (apiResult.Success)
        {
            if (apiResult.Response!.TryParseJson<VehicleTypeResponse>(out var result))
            {
                return result;
            }
        }

        return null;
    }
    public async Task<CarModelResponse?> GetModelsForMakeYearAsync(int makeId, int modelYear)
    {
        var url = _Configuration.GetSection("APIsSettings:GetCarModelUrl").Value!.Replace("{makeId}", makeId.ToString()).Replace("{modelyear}", modelYear.ToString());
        var apiResult = await _APICallingHelper.GetAPI(LogLevel.Information, Constants.ServicesNames.GetCarModel, url);

        if (apiResult.Success)
        {
            if (apiResult.Response!.TryParseJson<CarModelResponse>(out var result))
            {
                return result;
            }
        }

        return null;
    }
}