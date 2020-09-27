using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
<<<<<<< HEAD
using OffiRent.API.Domain.Persistence.Contexts;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Extensions;
=======
using Microsoft.Extensions.Logging;
using OffiRent.API.Domain.Persistence.Contexts;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
>>>>>>> feature/Departament-District-Office-models
using OffiRent.API.Persistence.Repositories;
using OffiRent.API.Services;

namespace OffiRent.API
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
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("supermarket-api-in-memory");
            });
            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();

<<<<<<< HEAD
            // Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IAccountPaymentMethodRepository, AccountPaymentMethodRepository>();

            services.AddRouting(options => options.LowercaseUrls = true);

            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountPaymentMethodService, AccountPaymentMethodService>();
            
=======
>>>>>>> feature/Departament-District-Office-models

            services.AddAutoMapper(typeof(Startup));
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
