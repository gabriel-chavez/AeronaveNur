using Aeronave.Domain.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Aeronave.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IAeronaveFactory, AeronaveFactory>();
            services.AddTransient<IModeloAeronaveFactory, ModeloAeronaveFactory>();
            services.AddTransient<IAeropuertoFactory, AeropuertoFactory>();


            return services;
        }
    }
}

