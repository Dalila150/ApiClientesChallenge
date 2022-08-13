using ApiClientes.Contextos;
using ApiClientes.Interfaces;
using ApiClientes.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ConexionSql>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("Challenge")));
            services.AddScoped<IClientes, ClientesRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Title = "ApiChallenge", Version = "v1" ,
                    Description =
                    "A tener en cuenta: \n" +
                    "Para el parametro de getLogs, el formato de la fecha ingresada debe ser del siguiente formato:  " +
                    "12_8_2022 " +
                    "//================================================================================================================================================================// " +
                    "Para el parametro de insertarCliente, modificarCliente y modificarClientePatch, el formato de la fecha debe ser tipo ISO: " +
                    "2011-11-11T11:11:11.111Z  " +
                    "//================================================================================================================================================================// " +
                    "A continuación se encuentra el link que dirige al repositorio de GitHub",
                    Contact = new OpenApiContact
                    {
                        Name = "Repositorio GitHub ApiChallenge",
                        Url = new Uri("https://github.com/Dalila150/ApiClientesChallenge"),
                    },

                }
                );
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiClientes v1"));
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
