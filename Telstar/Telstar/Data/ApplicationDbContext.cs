using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Telstar.Models;

namespace Telstar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Shipment> shipments { get; set; }

        public DbSet<Destination> destinations { get; set; }

        public DbSet<Edge> edges { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
                .HasData(
                new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Addis Abeba"

                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Amatave"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Bahr El Ghazal"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Cairo"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Congo"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Dakar"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Darfur"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "De Kanariske Oerne"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Dragebjerget"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Guldkysten"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Hvalbugten"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Kabalo"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Kap Guardafui"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Kap St. Marie"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Kapstaden"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Luanda"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Marrakesh"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Mocambique"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Omdurman"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Sahara"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Sierra Leone"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Slavekysten"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "St. Helena"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Suakin"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Tanger"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Timbuktu"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Tripoli"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Tunis"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Victoria Faldene"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Victoria Soeen"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Wadai"
                }, new Destination()
                {
                    Id = Guid.NewGuid(),
                    City = "Zanzibar"
                });
            base.OnModelCreating(builder);
        }
    }
}