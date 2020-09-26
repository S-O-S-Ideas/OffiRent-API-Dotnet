using System;
using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Extensions;

namespace OffiRent.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Country Entity

            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(p => p.CountryId);
            builder.Entity<Country>().Property(p => p.CountryId)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.Name)
                 .IsRequired().HasMaxLength(30);

            builder.Entity<Country>()
                 .HasMany(p => p.CountryCurrencies)
                 .WithOne(p => p.Country);

            builder.Entity<Country>()
                .HasMany(p => p.Departaments)
                .WithOne(p => p.Country);


            // Currency Entity

            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Currency>().HasKey(p => p.CurrencyId);
            builder.Entity<Currency>().Property(p => p.CurrencyId)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.Name)
                 .IsRequired().HasMaxLength(30);
            builder.Entity<Currency>().Property(p => p.Symbol) //simbolo de la moneda
                 .IsRequired().HasMaxLength(1);

            builder.Entity<Currency>()
                 .HasMany(p => p.CountryCurrencies)
                 .WithOne(p => p.Currency);

            // CountryCurrency Entity

            builder.Entity<CountryCurrency>().ToTable("CountryCurrencies");
            builder.Entity<CountryCurrency>().HasKey(p => p.Id);
            builder.Entity<CountryCurrency>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            

            builder.Entity<CountryCurrency>()
                 .HasOne(p => p.Country)
                 .WithMany(p => p.CountryCurrencies);

            builder.Entity<CountryCurrency>()
                 .HasOne(p => p.Currency)
                 .WithMany(p => p.CountryCurrencies);


            // Naming convention Policy
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
