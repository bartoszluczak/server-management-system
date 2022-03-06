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
using ServerManagementSystem.Models;

namespace ServerManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private ConnectionMultiplexer _redis;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
        .AddGraphQLServer()
        .AddQueryType<Query>();

            services.AddSingleton<RedisService>();

            var connectionURL = Configuration.GetValue<string>("RedisDB:connectionURL");
            var connectionPort = Configuration.GetValue<string>("RedisDB:connectionPort");
            var dbPassword = Configuration.GetValue<string>("RedisDB:dbPassword");
            var multiplexer = ConnectionMultiplexer.Connect($"{connectionURL}:{connectionPort}, password={dbPassword}");
            var servicesToMonitor = Configuration.GetSection("ServicesToMonitor").Get<string[]>().ToList();

            List<JobItem> AllJobsList = new List<JobItem>();
            AllJobsList.Add(new JobItem() { DataType = Type.GetType("ServerManagementSystem.Models.BiosDetails"), DataName = "BiosDetails", DataModel = "ServerManagementSystem.Models.BiosDetails", DataToQuery ="Win32_BIOS" });

            services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            services.Configure<QuartzOptions>(Configuration.GetSection("Quartz"));

            services.AddQuartz(q => {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                foreach (string serviceName in servicesToMonitor)
                {
                    var config = AllJobsList.Find(item => item.DataName.ToLower() == serviceName.ToLower());
                    var servicesJob = new JobKey($"{serviceName}Job", "group1");

                    //T type = Type.GetType(config.DataModel);
                    //q.AddJob<typoe>(servicesJob, job => job
                    //.UsingJobData("DataModel", config.DataModel)
                    //.UsingJobData("DataName", config.DataName)
                    //.UsingJobData("DataToQuery", config.DataToQuery));

                    //q.AddTrigger(trigger => trigger
                    //.WithIdentity(config.DataName)
                    //.ForJob(servicesJob)
                    //.StartNow()
                    //.WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                    //.RepeatForever()));
                }


                //var biosDetailsJob = new JobKey("biosDetailsJob", "group1");

                //q.AddJob<DefaultJob<BiosDetails>.Job>(biosDetailsJob, job => job
                //.UsingJobData("DataModel", "ServerManagementSystem.Models.BiosDetails")
                //.UsingJobData("DataName", "BiosDetails")
                //.UsingJobData("DataToQuery", "Win32_BIOS"));


                //q.AddTrigger(trigger => trigger
                //.WithIdentity("BiosDetails")
                //.ForJob(biosDetailsJob)
                //.StartNow()
                //.WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                //.RepeatForever()));


                //q.ScheduleJob<DefaultJob<BiosDetails>.Job>(trigger => trigger
                //.WithIdentity("BiosDetails")
                //.StartNow()
                //.WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                //.RepeatForever()));

                //q.ScheduleJob<BiosDetailsUpdate>(trigger => trigger
                //.WithIdentity("BiosDetails")
                //.StartNow()
                //.WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                //.RepeatForever()));

                q.ScheduleJob<MemoryDetailsUpdate>(trigger => trigger
                .WithIdentity("MemoryDetails")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever()));

                q.ScheduleJob<ProcessorDetailsUpdate>(trigger => trigger
                .WithIdentity("ProcessorDetails")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever()));

                q.ScheduleJob<ComputerSystemDetailsUpdate>(trigger => trigger
                .WithIdentity("ComputerSystemDetails")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever()));

                q.ScheduleJob<UpdatesDetailsUpdate>(trigger => trigger
                .WithIdentity("UpdatesDetails")
                .StartNow()
                .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever()));

                q.ScheduleJob<StorageDetailsUpdate>(trigger => trigger
                .WithIdentity("StorageDetails")
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

            ServerStartTime();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL("/api/graphql");
            });

            
        }

        public void ServerStartTime()
        {
            var connectionURL = Configuration.GetValue<string>("RedisDB:connectionURL");
            var connectionPort = Configuration.GetValue<string>("RedisDB:connectionPort");
            var dbPassword = Configuration.GetValue<string>("RedisDB:dbPassword");
            _redis = ConnectionMultiplexer.Connect($"{connectionURL}:{connectionPort}, password={dbPassword}");
            var time = DateTime.Now.ToString();
            var db = _redis.GetDatabase();
            db.StringSet("serverStartTime", time);
            _redis.Close();
        }
    }
}
