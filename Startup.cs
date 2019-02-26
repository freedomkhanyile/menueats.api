using menueats.api.API.ServicesExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using menueats.api.DAL.DbContext;
using Newtonsoft.Json;

namespace menueats.api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true)
                .AddEnvironmentVariables();

                Configuration = builder.Build();
        }


        // public IConfiguration Configuration { get; }
        IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigurSQLServerContext();
            services.ConfigureUserIdentity();
            services.ConfigureRepositoryWrapper();
            services.AddTransient<DBInitializer>();
            //use the command below to upgrade automapper used by DI
            //dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 3.0.1           
            services.AddAutoMapper();
            services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DBInitializer seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
              app.UseAuthentication();
            app.UseMvc();
            seeder.Seed().Wait();

        }
    }
}
