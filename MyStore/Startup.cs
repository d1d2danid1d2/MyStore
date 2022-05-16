using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyStore.Data;
using MyStore.DataPresentation;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static MyStore.Services.IOrderService;

namespace MyStore
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
            services.AddControllers().AddNewtonsoftJson(options =>
  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddControllers();
        
            //What id does
            //Finnaly we get to the part where we need to implement the classes that we created
            // First we add the databadse "StoreDb"
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyStore", Version = "v1" });
            });

            // This one
            services.AddDbContext<StoreContext>(
                options =>  options.UseSqlServer(Configuration.GetConnectionString("StoreDb"))
                );

            //Then we add the repository that we want and the class that it implements
            //SideNote: If we want to change the functionality of the app, we only need to change the things that appears here
            //IProductRepository and ProductRepository for example
            services.Configure<MySettings>(Configuration.GetSection("MySettings"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(OrdersProfile));
            services.AddScoped<IOrdersPresentation, OrdersPresentation>();            
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IOrderDetailPresentation, OrderDetailPresentation>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            services.AddScoped(typeof(CategoryProfile));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped(typeof(ProductProfile));
            services.AddScoped<IProductPresentation, ProductsPresentation>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddScoped(typeof(ShipperProfile));
            services.AddScoped<IShipperPresentation, ShipperPresentation>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IShipperRepository, ShipperRepository>();

            services.AddScoped(typeof(SupplierProfile));
            services.AddScoped<ISupplierPresentation, SupplierPresentation>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped(typeof(EmployeeProfile));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();

            services.AddScoped(typeof(CustomerProfile));
            services.AddScoped<ICustomerPresentation, CustomerPresentation>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyStore v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<SecurityHeaderMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
