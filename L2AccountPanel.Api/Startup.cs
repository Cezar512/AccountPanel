using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using L2AccountPanel.Core.Repositories;
using L2AccountPanel.Infrastructure.IoC;
using L2AccountPanel.Infrastructure.IoC.Modules;
using L2AccountPanel.Infrastructure.Mappers;
using L2AccountPanel.Infrastructure.Repositories;
using L2AccountPanel.Infrastructure.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using L2AccountPanel.Infrastructure.Mongo;
using L2AccountPanel.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Logging;
using L2AccountPanel.Infrastructure.Extensions;
using Microsoft.AspNetCore.Cors;
using L2AccountPanel.Infrastructure.EF;

namespace L2AccountPanel.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration {get;}
         public IContainer ApplicationContainer {get; private set;}

        public Startup(IHostingEnvironment env)
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
         public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDistributedMemoryCache();//23-03
            services.AddSession();//23-03

            services.AddEntityFrameworkMySql()
                    .AddDbContext<L2AccountPanelContext>();
            services.AddCors();
            var jwtSection = Configuration.GetSection("jwt");
            var jwtSettings = new JwtSettings();
            jwtSection.Bind(jwtSettings);
            services.AddJwt(jwtSettings);
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));

           
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            MongoConfigurator.Initialize();
            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if(generalSettings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }


            app.UseSession(); //23-03

            
            app.UseAuthentication();
            app.UseCors(
                options => options.WithOrigins("https://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            app.UseHttpsRedirection(); //
            app.UseHsts(); //

    //         app.UseCors(builder => builder
    // .WithOrigins("http://localhost:8080")
    // .AllowAnyMethod()
    // .AllowAnyHeader()
    // .AllowCredentials()
    // );
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() =>ApplicationContainer.Dispose());
        }
    }
}
