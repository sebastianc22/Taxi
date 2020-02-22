using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        //constructor - add line for me
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Class for mapping DB tables
        //"Taxis" Collection representing the taxis registered in the system.
        public DbSet<TaxiEntity> Taxis { get; set; }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        public DbSet<UserGroupEntity> UserGroups { get; set; }

        //Unique Index Validation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaxiEntity>()
                .HasIndex(t => t.Plaque)
                .IsUnique();

        }
    }
}
