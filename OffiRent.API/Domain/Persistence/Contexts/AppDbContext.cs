using System;
using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Extensions;

namespace OffiRent.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<AccountPaymentMethod> AccountPaymentMethods { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Departament> Departaments { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Publication>().ToTable("publications");
            builder.Entity<Publication>().HasKey(P => P.Id);
            builder.Entity<Publication>().Property(P => P.Id)
                .IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Publication>().Property(p => p.Puntuation)
                .IsRequired().HasMaxLength(10);
            builder.Entity<Publication>().Property(p => p.Description)
                .IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.Price)
                .IsRequired();
            builder.Entity<Publication>().Property(p => p.Status)
                .HasDefaultValue(true);
            builder.Entity<Publication>().Property(p => p.Comment)
                .HasMaxLength(100);
            builder.Entity<Publication>()
                .HasMany(p => p.Reservations)
                .WithOne(p => p.Publication)
                .HasForeignKey(p => p.PublicationId);
            builder.Entity<Publication>().HasData(
                new Publication
                {
                    Id = 100001,
                    Puntuation = "Buena",
                    Description = "new",
                    Price = 200,
                    Status = true,
                    Comment = "Comentario 01 "
                },
                new Publication
                {
                    Id = 100002,
                    Puntuation = "bad",
                    Description = "new",
                    Price = 300,
                    Status = false,
                    Comment = "Comentario 02"
                }
                );

            //Reservation
            builder.Entity<Reservation>().ToTable("reservation");
            builder.Entity<Reservation>().HasKey(P => P.Id);
            builder.Entity<Reservation>().Property(P => P.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Reservation>().Property(p => p.InitialDate)
                .IsRequired();
            builder.Entity<Reservation>().Property(p => p.EndDate)
                .IsRequired();
            builder.Entity<Reservation>().Property(p => p.InitialHour)
                .IsRequired();
            builder.Entity<Reservation>().Property(p => p.EndHour)
                .IsRequired();
            builder.Entity<Reservation>().Property(p => p.Status)
                .HasDefaultValue(false);

            builder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 30000,
                    InitialDate = 10,
                    EndDate = 15,
                    InitialHour = 8,
                    EndHour = 16,
                    Status = true
                },
                new Reservation
                {
                    Id = 30001,
                    InitialDate = 8,
                    EndDate = 22,
                    InitialHour = 8,
                    EndHour = 16,
                    Status = false
                }
                );


            // Account Entity
            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(a => a.Id);
            builder.Entity<Account>().Property(a => a.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Account>().Property(a => a.Email)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(a => a.Password)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(a => a.Identification)
                .HasMaxLength(50);
            builder.Entity<Account>().Property(a => a.FirstName)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(a => a.LastName)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(a => a.PhoneNumber)
                .HasMaxLength(50);
            builder.Entity<Account>().Property(p => p.IsPremium)
               .IsRequired();

            builder.Entity<Account>().HasData(
                new Account
                {
                    Id = 300,
                    Email = "juan@gmail.com",
                    Password = "1234",
                    Identification = "72901831",
                    FirstName = "Pepe",
                    LastName = "Cadena",
                    PhoneNumber = "920837182",
                    IsPremium = false,

                });
            
            
          


            // PaymentMethod Entity
            builder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            builder.Entity<PaymentMethod>().HasKey(p => p.Id);
            builder.Entity<PaymentMethod>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentMethod>().Property(p => p.CardNumber)
                .IsRequired().HasMaxLength(30);
            builder.Entity<PaymentMethod>().Property(p => p.OwnerName)
                .IsRequired().HasMaxLength(30);
            builder.Entity<PaymentMethod>().Property(p => p.DueDate)
                .IsRequired().HasMaxLength(30);
            builder.Entity<PaymentMethod>().Property(p => p.CV)
                .IsRequired().HasMaxLength(30);

            // AccountPaymentMethod Entity
            builder.Entity<AccountPaymentMethod>().ToTable("AccountPaymentMethods");
            builder.Entity<AccountPaymentMethod>().HasKey(ap => new { ap.AccountId, ap.PaymentMethodId });

            builder.Entity<AccountPaymentMethod>()
                .HasOne(ap => ap.Account)
                .WithMany(a => a.AccountPaymentMethods)
                .HasForeignKey(ap => ap.AccountId);

            builder.Entity<AccountPaymentMethod>()
                .HasOne(ap => ap.PaymentMethod)
                .WithMany(t => t.AccountPaymentMethods)
                .HasForeignKey(ap => ap.PaymentMethodId);
            // Office Entity
            builder.Entity<Office>().ToTable("Offices");
            builder.Entity<Office>().HasKey(p => p.Id);
            builder.Entity<Office>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Office>().Property(p => p.Address)
                .IsRequired();
            builder.Entity<Office>().Property(p => p.Floor)
                .IsRequired().HasMaxLength(30); 
            builder.Entity<Office>().Property(p => p.Capacity)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Office>().Property(p => p.AllowResource)
                .IsRequired();

            builder.Entity<Office>()
                .HasOne(p => p.District)
                .WithMany(p => p.Offices);

            builder.Entity<Office>()
                .HasOne(p => p.Publication);   //en duda

            //builder.Entity<Office>()
            //    .HasMany(p => p.Resources)
            //    .WithOne(p => p.Office);


            //District Entity
            builder.Entity<District>().ToTable("Districts");
            builder.Entity<District>().HasKey(p => p.Id);
            builder.Entity<District>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<District>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);

            builder.Entity<District>()
                .HasOne(p => p.Departament)
                .WithMany(p => p.Districts);

            builder.Entity<District>()
                .HasMany(p => p.Offices)
                .WithOne(p => p.District);


            // Departament Entity
            builder.Entity<Departament>().ToTable("Departaments");
            builder.Entity<Departament>().HasKey(p => p.Id);
            builder.Entity<Departament>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Departament>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);

            builder.Entity<Departament>()
                .HasOne(p => p.Country)
                .WithMany(p => p.Departaments);

            builder.Entity<Departament>()
                .HasMany(p => p.Districts)
                .WithOne(p => p.Departament);
            // OffiUser Entity



            builder.Entity<Account>()
                .HasMany(r => r.Reservations)
                .WithOne(r => r.Account)
                .HasForeignKey(r => r.Id);

            // Country Entity

            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.Name)
                 .IsRequired().HasMaxLength(30);

            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 100,
                    Name = "Peru"
                },
                new Country
                {
                    Id = 101,
                    Name = "Argentina"
                }
                );



            // Currency Entity

            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Currency>().HasKey(p => p.Id);
            builder.Entity<Currency>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.Name)
                 .IsRequired().HasMaxLength(30);
            builder.Entity<Currency>().Property(p => p.Symbol) //simbolo de la moneda
                 .IsRequired().HasMaxLength(1);

            builder.Entity<Currency>().HasData(
               new Currency
               {
                   Id = 200,
                   Name = "Nuevo Sol",
                   Symbol = 'S'
               },
               new Currency
               {
                Id = 201,
                    Name = "Dolar",
                    Symbol = '$'
                }
               );


            // CountryCurrency Entity

            builder.Entity<CountryCurrency>().ToTable("CountryCurrencies");
            builder.Entity<CountryCurrency>()
                .HasKey(p => new { p.CountryId, p.CurrencyId });


            builder.Entity<CountryCurrency>()
                 .HasOne(cc => cc.Country)
                 .WithMany(c => c.CountryCurrencies)
                 .HasForeignKey(cc => cc.CountryId);

            builder.Entity<CountryCurrency>()
                 .HasOne(p => p.Currency)
                 .WithMany(d => d.CountryCurrencies)
                 .HasForeignKey(p => p.CurrencyId);


            // Naming convention Policy
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
