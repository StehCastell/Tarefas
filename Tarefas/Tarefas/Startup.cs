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
using Tarefas.Infra;

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
                sw.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml"); //onde ele vai buscar o arquivo xml do swagger, onde tem a documenta��o xml
                sw.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TarefasAPI",
                    Description = "Projeto respons�vel por gerenciar tarefas do dia a dia",
                    Contact = new OpenApiContact
                    {
                        Name = "Stephanye Castellano",
                        Email = "stephanye.castellano@deal.com.br",
                        Url = new Uri("https://github.com/stehcastell"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Lincen�a MIT",
                        Url = new Uri("https://github.com/stehcastell"),
                    }
                });
            });

            #endregion Swagger

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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