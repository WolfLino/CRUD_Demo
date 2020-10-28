using AutoMapper;
using CRUD.API.Interfaces;
using CRUD.API.Services;
using CRUD.Application.Interfaces;
using CRUD.Application.Services;
using CRUD.Core.Configuration;
using CRUD.Core.Repositories;
using CRUD.Core.Repositories.Base;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Repository;
using CRUD.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace CRUD.API
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
            ConfigureCrudServices(services);
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
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

        private void ConfigureCrudServices(IServiceCollection services)
        {
            // Camada Core
            services.Configure<CrudSettings>(Configuration);

            // Camada Infra
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Camada Application
            services.AddScoped<ICustomerService, CustomerService>();

            // Camada API
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICustomerApiService, CustomerApiService>();
        }

        private void ConfigureDatabases(IServiceCollection services)
        {
            //services.AddDbContext<CrudContext>(c =>
            //    c.UseInMemoryDatabase("CrudConnection"));

            services.AddDbContext<CrudContext>(c =>
                c.UseMySql(Configuration.GetConnectionString("CrudConnection")));
        }
    }
}
