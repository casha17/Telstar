using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Telstar.Models;
using static Humanizer.In;

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
                .HasMany(e => e.FromEdges)
                .WithOne(e => e.fromDestination)
                .HasForeignKey(e => e.fromDestinationId);

            builder.Entity<Destination>()
            .HasMany(e => e.ToEdges)
            .WithOne(e => e.toDestination)
            .HasForeignKey(e => e.toDestinationId)
            .OnDelete(DeleteBehavior.Restrict);

            var addisId = Guid.Parse("0224c301-4a94-48f6-8df8-f27568583cf4");
            var addisName = "Addis Abeba";
            var VictoriaSoeenId = Guid.Parse("7a4aee29-b0a5-45db-90dc-3756abc449ec");
            var victoriName = "Victoria Soeen";


            

            builder.Entity<Destination>()
                .HasData(
                new Destination()
                {
                    Id = addisId,
                    City = addisName
                    

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
                    Id = VictoriaSoeenId,
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


            builder.Entity<Edge>().HasData(
               new Edge() {
                Cost= 12,
                From = addisName,
                To = victoriName,
                fromDestinationId = addisId,
                toDestinationId = VictoriaSoeenId,
                Id = Guid.NewGuid(),
                TimeHours= 12,
                }
            );

            base.OnModelCreating(builder);
        }
    }
}