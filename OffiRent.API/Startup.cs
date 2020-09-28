using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OffiRent.API.Domain.Persistence.Contexts;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services;
using OffiRent.API.Extensions;
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
                // options.UseInMemoryDatabase("offirent-api-in-memory");
                //options.UseMySQL(Configuration.GetConnectionString("MySQLConnection"));
                options.UseNpgsql("server=localhost;port=5432;database=suparmarket;uid=postgres;password=postgres");

            });

            // Repositories
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICountryCurrencyRepository, CountryCurrencyRepository>();

            services.AddRouting(options => options.LowercaseUrls = true);

            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryCurrencyService, CountryCurrencyService>();
            

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomSwagger();
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

            app.UseCustomSwagger();
        }
    }
}
