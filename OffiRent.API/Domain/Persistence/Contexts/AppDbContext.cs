using System;
using Microsoft.EntityFrameworkCore;
using OffiRent.API.Domain.Models;
using OffiRent.API.Extensions;

namespace OffiRent.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<OffiUser> OffiUsers { get; set; }
        public DbSet<OffiProvider> OffiProviders { get; set; }
               
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // OffiUser Entity

            builder.Entity<OffiUser>().ToTable("OffiUsers");
            builder.Entity<OffiUser>().HasKey(p => p.Id);
            builder.Entity<OffiUser>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OffiUser>().Property(p => p.UserPunctuation)
                .IsRequired();
            builder.Entity<OffiUser>().Property(p => p.HasDiscount)
                 .IsRequired();

            builder.Entity<OffiUser>()
                 .HasOne(p => p.OffiUser)
                 .WithMany(p => p.Reservations);

            builder.Entity<OffiUser>()
                .HasOne(p => p.OffiUser)
                .WithMany(p => p.Discounts);

            //la de herencia de offiuser 
            //esta wbd facil esta mal si no es hasone withmany es hasmany.reservations withone.offiuser


            // OffiProvider Entity

            builder.Entity<OffiProvider>().ToTable("OffiProviders");
            builder.Entity<OffiProvider>().HasKey(p => p.Id);
            builder.Entity<OffiProvider>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OffiProvider>().Property(p => p.PremiumStatus)
                .IsRequired();
            builder.Entity<OffiProvider>().Property(p => p.Punctuation)
                 .IsRequired();
            builder.Entity<OffiProvider>().Property(p => p.NumberOfPublication)
                 .IsRequired();
            builder.Entity<OffiProvider>().Property(p => p.NumberOfReservationCompleted)
                 .IsRequired();

            builder.Entity<OffiProvider>()
                 .HasMany(p => p.Publications)
                 .WithOne(p => p.OffiProvider);

           
            //la de herencia de offiprovider

            // Naming convention Policy
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}