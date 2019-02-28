using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("Default",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ICartRepository, CartRepository>();
            services.AddSingleton<IEquipmentRepository, EquipmentRepository>();
            services.AddSingleton<IFeeRepository, FeeRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IInvoiceGenerator, PlainTextInvoiceGenerator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Default");

            app.UseMvc();
        }
    }
}
