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


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            builder.Entity<Account>().HasData
                (
                new Account
                {
                    Id = 300,
                    Email = "juan@gmail.com",
                    Password = "1234",
                    Identification = "72901831",
                    Type = false,
                    FirstName = "Pepe",
                    LastName = "Cadena",
                    PhoneNumber = "920837182"
                }
                );


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


            // Naming convention Policy
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}