using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Quartz;
using ServerManagementSystem.Jobs;

namespace ServerManagementSystem
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
            services.Configure<QuartzOptions>(Configuration.GetSection("Quartz"));

            services.AddQuartz(q => {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });


                q.ScheduleJob<SimpleJob>(trigger => trigger
                .WithIdentity("Test")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever())); 
                
                q.ScheduleJob<BiosDetailsUpdate>(trigger => trigger
                .WithIdentity("BiosDetails")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever()));

            });

            services.AddQuartzHostedService(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.SetIsOriginAllowed(origin => true)
                       .AllowAnyMethod()
                       .AllowAnyHeader().
                       AllowCredentials();
            }));
            services.AddControllers();
            services.AddTransient<ManagementService>();

            services.AddQuartzHostedService(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
