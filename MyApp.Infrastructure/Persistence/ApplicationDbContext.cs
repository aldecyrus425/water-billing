using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.UserId);

                entity.HasMany(x => x.MeterReadings)
                .WithOne(x => x.Reader)
                .HasForeignKey(x => x.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.Payments)
                .WithOne(x => x.UserReceived)
                .HasForeignKey(x => x.ReceivedBy)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(x => x.CustomerId);

                entity.HasMany(x => x.WaterMeters)
                .WithOne(x => x.Customers)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.Bills)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WaterMeters>(entity =>
            {
                entity.HasKey(x => x.WaterMeterId);

                entity.HasMany(x => x.MeterReadings)
                .WithOne(x => x.WaterMeters)
                .HasForeignKey(x => x.WaterMeterId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BillingRates>(entity =>
            {
                entity.HasKey(x => x.BillingRateId);
            });

            modelBuilder.Entity<MeterReadings>(entity =>
            {
                entity.HasKey(x => x.MeterReadingId);
            });

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasKey(x => x.BillId);

                entity.HasMany(x => x.BillItems)
                .WithOne(x => x.Bills)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.Payments)
                .WithOne(x => x.Bills)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.Penalties)
                .WithOne(x => x.Bills)
                .HasForeignKey(x => x.PenaltyId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BillItems>(entity =>
            {
                entity.HasKey(x => x.BillItemId);
            });

            modelBuilder.Entity<Penalties>(entity =>
            {
                entity.HasKey(x => x.PenaltyId);
            });

            modelBuilder.Entity<WaterMeterReplacements>(entity =>
            {
                entity.HasKey(x => x.WaterMeterReplacementId);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(x => x.PaymentId);
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BillingRates> BillingRates { get; set; }
        public DbSet<BillItems> BillItems { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<MeterReadings> MeterReadings { get; set; }
        public DbSet<Payments> Payments {  get; set; }
        public DbSet<Penalties> Penalties { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users {  get; set; }
        public DbSet<WaterMeterReplacements> WaterMeterReplacement { get; set; }
        public DbSet<WaterMeters> WaterMeters { get; set; }
    }
}
