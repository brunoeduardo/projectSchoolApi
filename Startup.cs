using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjectSchool_API.Data;

namespace ProjectSchool_API
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
            string connectionString =
                Configuration.GetConnectionString("MySqlConnection");

            services
                .AddDbContext<DataContext>(opt =>
                {
                    opt
                        .UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString));
                });

            // services
            //     .AddDbContext<DataContext>(x =>
            //         x
            //             .UseMySql(Configuration
            //                 .GetConnectionString("MySqlConnection")));
            services.AddControllers();

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;
                });

            services
                .AddControllersWithViews(options =>
                {
                    options.AllowEmptyInputInBodyModelBinding = true;
                });

            services.AddScoped<IRepository, Repository>();

            services
                .AddSwaggerGen(c =>
                {
                    c
                        .SwaggerDoc("v1",
                        new OpenApiInfo {
                            Title = "ProjectSchool_API",
                            Version = "v1"
                        });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app
                    .UseSwaggerUI(c =>
                        c
                            .SwaggerEndpoint("/swagger/v1/swagger.json",
                            "ProjectSchool_API v1"));
            }

            // app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app
                .UseCors(x =>
                    x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
