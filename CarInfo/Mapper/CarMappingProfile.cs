namespace CarInfo.Mapper;

using AutoMapper;

using CarInfo.Models;
using CarInfo.Services.Entites;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<CarMakeResponse, CarMakeViewModel>();
        CreateMap<Services.Entites.CarMake, Models.CarMake>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MakeID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MakeName));


        CreateMap<CarModelResponse, CarModelViewModel>();
        CreateMap<Services.Entites.CarModel, Models.CarModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MakeID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MakeName));


        CreateMap<VehicleTypeResponse, VehicleTypeViewModel>();
        CreateMap<Services.Entites.VehicleType, Models.VehicleType>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VehicleTypeId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.VehicleTypeName));
    }
}