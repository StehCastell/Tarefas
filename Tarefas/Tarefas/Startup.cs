using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Domain.Handlers;
using Tarefas.Domain.Interfaces.Handlers;
using Tarefas.Domain.Interfaces.Repositories;
using Tarefas.Infra;
using Tarefas.Infra.Data.DataContexts;
using Tarefas.Infra.Data.Repositories;

namespace Tarefas.API
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
            #region AppSettings

            AppSettings appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            #endregion AppSettings

            #region Swagger

            services.AddSwaggerGen(sw =>
            {
                sw.DescribeAllParametersInCamelCase(); //todos os parametros viram camelcase
                sw.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml"); //onde ele vai buscar o arquivo xml do swagger, onde tem a documentação xml
                sw.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TarefasAPI",
                    Description = "Projeto responsável por gerenciar tarefas do dia a dia",
                    Contact = new OpenApiContact
                    {
                        Name = "Stephanye Castellano",
                        Email = "stephanye.castellano@deal.com.br",
                        Url = new Uri("https://github.com/stehcastell"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Lincença MIT",
                        Url = new Uri("https://github.com/StehCastell/Tarefas/blob/main/LICENSE"),
                    }
                });
            });

            #endregion Swagger

            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion DataContexts

            #region Repositories

            services.AddTransient<ITarefaRepository, TarefaRepository>();

            #endregion Repositories

            #region Handlers

            services.AddTransient<ITarefaHandler, TarefaHandler>();

            #endregion Handlers

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarefas.API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
