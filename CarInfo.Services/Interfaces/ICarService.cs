namespace CarInfo.Services.Interfaces;

using CarInfo.Services.Entites;

public interface ICarService
{
    Task<CarMakeResponse?> GetAllMakesAsync();
    Task<VehicleTypeResponse?> GetVehicleTypesForMakeAsync(int makeId);
    Task<CarModelResponse?> GetModelsForMakeYearAsync(int makeId, int modelYear);
}