using Microsoft.Extensions.DependencyInjection;
using Nasa.MarsRover.Application.Interfaces;
using Nasa.MarsRover.Application.Services;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Services;
using Nasa.MarsRover.Domain.Validations;

namespace Nasa.MarsRover.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddResolveDependencies(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IPlateauAppService, PlateauAppService>();
            services.AddScoped<IRoverAppService, RoverAppService>();
            services.AddScoped<ICoordinatesAppSevice, CoordinatesAppSevice>();

            //Domain
            services.AddScoped<IRoverService, RoverService>();
            services.AddScoped<IPlateauValidation, PlateauValidation>();
            services.AddScoped<IRoverValidation, RoverValidation>();
            services.AddScoped<IValidationResult, ValidationResult>();

            return services;
        }
    }
}
