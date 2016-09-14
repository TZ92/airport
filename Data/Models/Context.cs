using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class Context : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public static Context Create()
        {
            return new Context();
        }

        public Context()
            : base("Name=airport2Context")
        {
        }

        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airlinecompany> Airlinecompanys { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
        public DbSet<Client> Clients { get; set; }
        //public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                   .HasRequired(f => f.DepartLocation)
                   .WithMany(t => t.FlightDepart)
                   .HasForeignKey(f => f.DepartLocationId)
                   .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                  .HasRequired(f => f.ArrivalLocation)
                  .WithMany(t => t.FlightArrival)
                  .HasForeignKey(f => f.ArrivalLocationId)
                  .WillCascadeOnDelete(false);


            modelBuilder.Entity<User>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CustomUserClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CustomUserRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        }
    }
}
