namespace CarInfo.Registrar;

using CarInfo.Mapper;
using CarInfo.Middlewares;
using CarInfo.Services.Services;
using CarInfo.Services.Interfaces;

public static class Registrar
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAPICallingHelper, APICallingHelper>();
        builder.Services.AddScoped<ICarService, CarService>();
        builder.Services.AddSingleton<ILog, Logger>();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddSingleton<ExceptionHandlerMiddleware>();

        builder.Services.AddAutoMapper(typeof(CarMappingProfile));

        return builder;
    }
}