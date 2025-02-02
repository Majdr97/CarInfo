namespace CarInfo.Pages;

using AutoMapper;
using CarInfo.Models;
using CarInfo.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel(ICarService carService, IMapper mapper) : PageModel
{
    private readonly ICarService _carService = carService;
    private readonly IMapper _mapper = mapper;

    public async Task<JsonResult> OnGetCarMakes()
    {
        var makesResponse = await _carService.GetAllMakesAsync();
        CarMakeViewModel carMakesModel = _mapper.Map<CarMakeViewModel>(makesResponse);
        return new JsonResult(carMakesModel);
    }

    public async Task<JsonResult> OnGetVehicleTypes(int makeId)
    {
        var typesResponse = await _carService.GetVehicleTypesForMakeAsync(makeId);
        VehicleTypeViewModel vehicleTypeModel = _mapper.Map<VehicleTypeViewModel>(typesResponse);
        return new JsonResult(vehicleTypeModel);
    }

    public async Task<JsonResult> OnGetCarModels(int makeId, int modelYear)
    {
        var modelsResponse = await _carService.GetModelsForMakeYearAsync(makeId, modelYear);
        CarModelViewModel carModelModel = _mapper.Map<CarModelViewModel>(modelsResponse);
        return new JsonResult(carModelModel);
    }
}