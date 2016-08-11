using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MessageService.Domain;
using MessageService.Infra.Bus;
using MessageWebApi.Midleware;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MessageService.Infra.Repository;
using MessageService.Domain.Repositories;
using MessageService.Domain.CommandHandlers;

namespace MessageWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            
            #region IoC
            // Adiciona o Bus como uma Singleton
            services.AddSingleton<IBus, MessageQueueBus>();

            // Adiciona os demais objetos
            services.AddScoped<IActivityRepository, ActivityRepository>();
            containerBuilder.RegisterType<RegisterSingleActivityHandler>();
            #endregion

            // Configurações do BUS
            services.Configure<BUSSettings>(Configuration.GetSection("BUSSettings"));

            // Usa o Autofact para incluir a IoC do Provedor de Serviços
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();

            // Adiciona o midleware para registar os handlers
            app.UseMiddleware<RegisterHandlerMidleware>();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
