using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopDatabaseImplement.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FlowerShopBusinessLogic.HelperModels;
using System;

namespace FlowerShopRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IFlowerStorage, FlowerStorage>();
            services.AddTransient<IStorehouseStorage, StorehouseStorage>();
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<OrderLogic>();
            services.AddTransient<ClientLogic>();
            services.AddTransient<FlowerLogic>();
            services.AddTransient<MailLogic>();
            services.AddTransient<StorehouseLogic>();
            services.AddTransient<ComponentLogic>();
            services.AddControllers().AddNewtonsoftJson();

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = Configuration["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(Configuration["SmtpClientPort"]),
                MailLogin = Configuration["MailLogin"],
                MailPassword = Configuration["MailPassword"],
            });
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