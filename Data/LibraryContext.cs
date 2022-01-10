using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMediiMaster_BogdanIstrate.Models;

namespace ProjectMediiMaster_BogdanIstrate.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) :
        base(options)
        {
        }
        public DbSet<AppCustomer> AppCustomers { get; set; }
        public DbSet<GuitarOrder> GuitarOrders { get; set; }
        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<ReleasedGuitar> ReleasedGuitars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppCustomer>().ToTable("AppCustomer");
            modelBuilder.Entity<GuitarOrder>().ToTable("GuitarOrder");
            modelBuilder.Entity<Guitar>().ToTable("Guitar");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Factory>().ToTable("Publisher");
            modelBuilder.Entity<ReleasedGuitar>().ToTable("ReleasedGuitar");

            modelBuilder.Entity<ReleasedGuitar>()
            .HasKey(c => new { c.GuitarID, c.FactoryID });
        }

    }
}
