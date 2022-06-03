using Aeronave.Application;
using Aeronave.Domain.Repositories;
using Aeronave.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aeronave.Infraestructure.EF;
using Aeronave.Infraestructure.EF.Repository;

namespace Aeronave.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString =
                configuration.GetConnectionString("PedidoDbConnectionString");

            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IAeronaveRepository, AeronaveRepository>();
            services.AddScoped<IModeloAeronaveRepository, ModeloAeronaveRepository>();
            services.AddScoped<IAeropuertoRepository, AeropuertoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
