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
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
