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
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace Aeronave.Infraestructure
{
    [ExcludeFromCodeCoverage]
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

            AddRabbitMq(services, configuration);

            return services;
        }
        private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((context, cfg) =>
                {
                    var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                    cfg.Host(uri);
                });
            });

            //services.AddSingleton<RabbitMqOptions>(sp =>
            //{
            //    var configuration=sp.GetRequiredService<IConfiguration>();
            //    return configuration.GetSection("RabbitMq").Get<RabbitMqOptions>
            //});
        }
    }
}
