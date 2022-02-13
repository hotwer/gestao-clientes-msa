using GestaoClientesMSA.Controllers.Dtos;
using GestaoClientesMSA.Controllers.Mappers;
using GestaoClientesMSA.Database;
using GestaoClientesMSA.Database.Repositories;
using GestaoClientesMSA.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GestaoClientesMSA
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestaoClientesMSA", Version = "v1" });
                
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            BootstrapSessionFactory(services);

            CreateDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestaoClientesMSA v1"));
            }

            app.UseCors(options => 
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void CreateDependencies(IServiceCollection services)
        {
            // mappers
            services.AddScoped<IMapper<Cliente, ClienteDto>, ClienteMapper>();
            services.AddScoped<IMapper<Telefone, TelefoneDto>, TelefoneMapper>();
            
            // repositories
            services.AddScoped<IRepository<Cliente>, ClienteRepository>();
        }

        private void BootstrapSessionFactory(IServiceCollection services)
        {
            services.AddSingleton<ISessionFactory>(
                SessionFactoryBuilder.Build(Configuration.GetConnectionString("Default"))
            );
        }
    }
}
