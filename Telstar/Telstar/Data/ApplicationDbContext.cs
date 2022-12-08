using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Telstar.Models;
using static Humanizer.In;

namespace Telstar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private static int costprsegmentUSD = 3;
        private static int timeprsegmenthours = 4;

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
            var amataveId = Guid.Parse("79feb834-7446-4104-9f21-23892abd6d50");
            var amataveName = "Amatave";
            var bahrID = Guid.Parse("fb3eb190-83c2-4d0b-932d-435e48293013");
            var bahrName = "Bahr El Ghazal";
            var cairoId = Guid.Parse("b5c29783-f4e9-4adc-be1d-2dc760865357");
            var cairoName = "Cairo";
            var congoId = Guid.Parse("4e173e38-3feb-4fbf-b32e-39e7af310aa0");
            var congoName = "Congo";
            var dakarId = Guid.Parse("4f05293d-778b-4344-bf96-eb8be8baafa0");
            var dakarName = "Dakar";
            var darfurId = Guid.Parse("5e991c00-c1de-45f5-9134-1f6b0267793a");
            var darfurName = "Darfur";
            var kanariskeId = Guid.Parse("8d38846e-f4c3-4994-94b8-05e18e221334");
            var kanariskeName = "De Kanariske Oeer";
            var dragebId = Guid.Parse("c67fd119-9dc7-441c-8335-cfced090624b");
            var dragebName = "Dragebjerget";
            var guldKystId = Guid.Parse("a8100e5c-42bf-4039-be60-8d5390fecf35");
            var guldKystName = "Guld kysten";
            var hvalbugtenId = Guid.Parse("db372b4a-782f-444a-8976-a57e0883573a");
            var hvalbugtenName = "Hvalbugten";
            var kabaloId = Guid.Parse("60b1c48c-4d2e-4a65-bf3b-c9315f23ab27");
            var kabaloName = "Kabalo";
            var kapGuardaId = Guid.Parse("45832d16-eadb-4bbf-b8f1-f2eb6b826d41");
            var kapGuardaName = "Kap Guardafui";
            var kapMarieId = Guid.Parse("6ab3d246-2a09-4fbc-bc23-1d3c672c4236");
            var kapMarieName = "Kap St.Marie";
            var kapstadenId = Guid.Parse("84bbf8a7-07e1-41a5-ba00-302d98886fb9");
            var kapstadenName = "Kapstaden";
            var luandaId = Guid.Parse("fdb01392-b9af-4dbb-a6d8-4b5805811377");
            var luandaName = "Luanda";
            var marrakeshId = Guid.Parse("65c280d6-e9fa-4dd4-8f3c-918aeef28e1b");
            var marrakeshName = "Marrakesh";
            var mocambiqueId = Guid.Parse("2b102387-95e6-4603-bb33-644352a280ad");
            var mocambiqueName = "Mocambique";
            var omdurmanId = Guid.Parse("5ad64a19-b27a-48b9-95cf-0332e88d7fbf");
            var omdurmanName = "Omdurman";
            var saharaId = Guid.Parse("ac9877b1-d2ba-4cee-b54f-057944515b8b");
            var saharaName = "Sahara";
            var sLeoneId = Guid.Parse("7289b9c0-d3a2-47c4-8ef1-42b761a9071b");
            var sleoneName = "Sierra Leone";
            var slavekystenId = Guid.Parse("d8409ad5-0806-404f-9c54-b017c969c19c");
            var slavekystenName = "Slavekysten";
            var stHelenaId = Guid.Parse("a32cba22-43d5-44ff-8256-9999d70e3ba0");
            var stHelenaName = "St. Helena";
            var suakinId = Guid.Parse("017f584a-c867-494b-809c-f4e2bfa7577e");
            var suakinName = "Suakin";
            var TangerId = Guid.Parse("400b7f86-7e41-456e-8d78-d80c6fd14160");
            var TangerName = "Tanger";
            var TimbuktuId = Guid.Parse("0c7e8374-f30c-4895-bfe9-63f76d424786");
            var timbuktuName = "Timbuktu";
            var tripoliId = Guid.Parse("0b6f1334-e14a-4eba-a4a5-dfdd2f3f6bb5");
            var tripoliIdName = "Tripoli";
            var tunisId = Guid.Parse("4ec48c75-d78f-4c52-bdc9-27c81359ad25");
            var tunisName = "Tunis";
            var victoriafaldeneId = Guid.Parse("5b787360-98aa-48ff-b180-2343d1b4a22d");
            var victoriafaldeneName = "Victoria Faldene";
            var VictoriaSoeenId = Guid.Parse("7a4aee29-b0a5-45db-90dc-3756abc449ec");
            var victoriaSoeenName = "Victoria Soeen";
            var wadaiId = Guid.Parse("6762ac25-184c-45fe-ba68-de1cbfc3a531");
            var wadaiName = "Wadai";
            var zanzibarId = Guid.Parse("fd6624c4-846b-4d52-adda-b26171edc520");
            var zanzibarName = "Zanzibar";

            builder.Entity<Destination>()
                .HasData(
                new Destination()
                {
                    Id = addisId,
                    City = addisName
                }, new Destination()
                {
                    Id = amataveId,
                    City = amataveName
                }, new Destination()
                {
                    Id = bahrID,
                    City = bahrName
                }, new Destination()
                {
                    Id = cairoId,
                    City = cairoName
                }, new Destination()
                {
                    Id = congoId,
                    City = congoName
                }, new Destination()
                {
                    Id = dakarId,
                    City = dakarName
                }, new Destination()
                {
                    Id = darfurId,
                    City = darfurName
                }, new Destination()
                {
                    Id = kanariskeId,
                    City = kanariskeName
                }, new Destination()
                {
                    Id = dragebId,
                    City = dragebName
                }, new Destination()
                {
                    Id = guldKystId,
                    City = guldKystName
                }, new Destination()
                {
                    Id = hvalbugtenId,
                    City = hvalbugtenName
                }, new Destination()
                {
                    Id = kabaloId,
                    City = kabaloName
                }, new Destination()
                {
                    Id = kapGuardaId,
                    City = kapGuardaName
                }, new Destination()
                {
                    Id = kapMarieId,
                    City = kapMarieName
                }, new Destination()
                {
                    Id = kapstadenId,
                    City = kapstadenName
                }, new Destination()
                {
                    Id = luandaId,
                    City = luandaName
                }, new Destination()
                {
                    Id = marrakeshId,
                    City = marrakeshName
                }, new Destination()
                {
                    Id = mocambiqueId,
                    City = mocambiqueName
                }, new Destination()
                {
                    Id = omdurmanId,
                    City = omdurmanName
                }, new Destination()
                {
                    Id = saharaId,
                    City = saharaName
                }, new Destination()
                {
                    Id = sLeoneId,
                    City = sleoneName
                }, new Destination()
                {
                    Id = slavekystenId,
                    City = slavekystenName
                }, new Destination()
                {
                    Id = stHelenaId,
                    City = stHelenaName
                }, new Destination()
                {
                    Id = suakinId,
                    City = suakinName
                }, new Destination()
                {
                    Id = TangerId,
                    City = TangerName
                }, new Destination()
                {
                    Id = TimbuktuId,
                    City = timbuktuName
                }, new Destination()
                {
                    Id = tripoliId,
                    City = tripoliIdName
                }, new Destination()
                {
                    Id = tunisId,
                    City = tunisName
                }, new Destination()
                {
                    Id = victoriafaldeneId,
                    City = victoriafaldeneName
                }, new Destination()
                {
                    Id = VictoriaSoeenId,
                    City = victoriaSoeenName
                }, new Destination()
                {
                    Id = wadaiId,
                    City = wadaiName
                }, new Destination()
                {
                    Id = zanzibarId,
                    City = zanzibarName
                });

            builder.Entity<Edge>().HasData(
               new Edge() {
                   Id = Guid.NewGuid(),
                   fromDestinationId = TangerId,
                   toDestinationId = marrakeshId,
                   From = TangerName,
                   To = marrakeshName,
                   Cost = costprsegmentUSD * 2,
                   TimeHours = timeprsegmenthours * 2
                }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = TangerId,
                   toDestinationId = saharaId,
                   From = TangerName,
                   To = saharaName,
                   Cost = costprsegmentUSD*5,
                   TimeHours = timeprsegmenthours*5,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = TangerId,
                   toDestinationId = tunisId,
                   From = TangerName,
                   To = tunisName,
                   Cost = costprsegmentUSD *5,
                   TimeHours = timeprsegmenthours *5,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = tunisId,
                   toDestinationId = tripoliId,
                   From = tunisName,
                   To = tripoliIdName,
                   Cost = costprsegmentUSD * 3,
                   TimeHours = timeprsegmenthours * 3,
               }
               );

            builder.Entity<Edge>().HasData(
            new Edge()
            {
                Id = Guid.NewGuid(),
                fromDestinationId = tripoliId,
                toDestinationId = omdurmanId,
                From = tripoliIdName,
                To = omdurmanName,
                Cost = costprsegmentUSD * 6,
                TimeHours = timeprsegmenthours * 6,
            }
            );

               builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = omdurmanId,
                   toDestinationId = cairoId,
                   From = omdurmanName,
                   To = cairoName,
                   Cost = costprsegmentUSD * 4,
                   TimeHours = timeprsegmenthours *4,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = marrakeshId,
                   toDestinationId = dakarId,
                   From = marrakeshName,
                   To = dakarName,
                   Cost = costprsegmentUSD * 8,
                   TimeHours = timeprsegmenthours * 8,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = dakarId,
                   toDestinationId = sLeoneId,
                   From = dakarName,
                   To = sleoneName,
                   Cost = costprsegmentUSD * 4,
                   TimeHours = timeprsegmenthours * 4,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = sLeoneId,
                   toDestinationId = TimbuktuId,
                   From = sleoneName,
                   To = timbuktuName,
                   Cost = costprsegmentUSD * 5,
                   TimeHours = timeprsegmenthours * 5,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = sLeoneId,
                   toDestinationId = guldKystId,
                   From = sleoneName,
                   To = guldKystName,
                   Cost = costprsegmentUSD * 5,
                   TimeHours = timeprsegmenthours *5,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = TimbuktuId,
                   toDestinationId = slavekystenId,
                   From = timbuktuName,
                   To = slavekystenName,
                   Cost = costprsegmentUSD * 5,
                   TimeHours = timeprsegmenthours *5,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = slavekystenId,
                   toDestinationId = wadaiId,
                   From = slavekystenName,
                   To = wadaiName,
                   Cost = costprsegmentUSD * 7,
                   TimeHours = timeprsegmenthours * 7,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = slavekystenId,
                   toDestinationId = congoId,
                   From = slavekystenName,
                   To = congoName,
                   Cost = costprsegmentUSD * 5,
                   TimeHours = timeprsegmenthours * 5,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = slavekystenId,
                   toDestinationId = darfurId,
                   From = slavekystenName,
                   To = darfurName,
                   Cost = costprsegmentUSD * 7,
                   TimeHours = timeprsegmenthours * 7,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = darfurId,
                   toDestinationId = wadaiId,
                   From = darfurName,
                   To = wadaiName,
                   Cost = costprsegmentUSD * 4,
                   TimeHours = timeprsegmenthours *4,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = saharaId,
                   toDestinationId = darfurId,
                   From = saharaName,
                   To = darfurName,
                   Cost = costprsegmentUSD * 8,
                   TimeHours = timeprsegmenthours *8,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = omdurmanId,
                   toDestinationId = darfurId,
                   From = omdurmanName,
                   To = darfurName,
                   Cost = costprsegmentUSD * 3,
                   TimeHours = timeprsegmenthours * 3,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = suakinId,
                   toDestinationId = darfurId,
                   From = suakinName,
                   To = darfurName,
                   Cost = costprsegmentUSD * 4,
                   TimeHours = timeprsegmenthours * 4,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = darfurId,
                   toDestinationId = bahrID,
                   From = darfurName,
                   To = bahrName,
                   Cost = costprsegmentUSD * 2,
                   TimeHours = timeprsegmenthours *2,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = suakinId,
                   toDestinationId = addisId,
                   From = suakinName,
                   To = addisName,
                   Cost = costprsegmentUSD * 3,
                   TimeHours = timeprsegmenthours *3,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = VictoriaSoeenId,
                   toDestinationId = bahrID,
                   From = victoriaSoeenName,
                   To = bahrName,
                   Cost = costprsegmentUSD * 2,
                   TimeHours =timeprsegmenthours * 2,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = VictoriaSoeenId,
                   toDestinationId = addisId,
                   From = victoriaSoeenName,
                   To = addisName,
                   Cost = costprsegmentUSD * 3,
                   TimeHours = timeprsegmenthours * 3,
               }
            );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = addisId,
                   toDestinationId = kapGuardaId,
                   From = addisName,
                   To = kapGuardaName,
                   Cost = costprsegmentUSD * 3,
                   TimeHours = timeprsegmenthours * 3,
               }
            );
            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = VictoriaSoeenId,
                   toDestinationId = kabaloId,
                   From = victoriaSoeenName,
                   To = kabaloName,
                   Cost = costprsegmentUSD * 4,
                   TimeHours = timeprsegmenthours * 4,
               }
            );

           builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = VictoriaSoeenId,
                   toDestinationId = mocambiqueId,
                   From = victoriafaldeneName,
                   To = mocambiqueName,
                   Cost = costprsegmentUSD * 6,
                   TimeHours = timeprsegmenthours * 6,
               }
            );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = kapGuardaId,
                    toDestinationId = zanzibarId,
                    From = kapGuardaName,
                    To = zanzibarName,
                    Cost = costprsegmentUSD * 6,
                    TimeHours = timeprsegmenthours * 6,
                }
             );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = zanzibarId,
                   toDestinationId = mocambiqueId,
                   From = zanzibarName,
                   To = mocambiqueName,
                   Cost = costprsegmentUSD * 3,
                   TimeHours = timeprsegmenthours * 3,
               }
            );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = congoId,
                    toDestinationId = luandaId,
                    From = congoName,
                    To = luandaName,
                    Cost = costprsegmentUSD * 3,
                    TimeHours = timeprsegmenthours * 3,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = kabaloId,
                    toDestinationId = luandaId,
                    From = kabaloName,
                    To = luandaName,
                    Cost = costprsegmentUSD * 4,
                    TimeHours = timeprsegmenthours * 4,
                }
             );

            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = luandaId,
                   toDestinationId = mocambiqueId,
                   From = luandaName,
                   To = mocambiqueName,
                   Cost = costprsegmentUSD * 10,
                   TimeHours = timeprsegmenthours * 10,
               }
            );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = luandaId,
                    toDestinationId = dragebId,
                    From = luandaName,
                    To = dragebName,
                    Cost = costprsegmentUSD * 11,
                    TimeHours = timeprsegmenthours * 11,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = mocambiqueId,
                    toDestinationId = dragebId,
                    From = mocambiqueName,
                    To = dragebName,
                    Cost = costprsegmentUSD * 4,
                    TimeHours = timeprsegmenthours * 4,
                }
             );


            builder.Entity<Edge>().HasData(
               new Edge()
               {
                   Id = Guid.NewGuid(),
                   fromDestinationId = mocambiqueId,
                   toDestinationId = victoriafaldeneId,
                   From = mocambiqueName,
                   To = victoriafaldeneName,
                   Cost = costprsegmentUSD * 5,
                   TimeHours = timeprsegmenthours * 5,
               }
            );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = victoriafaldeneId,
                    toDestinationId = dragebId,
                    From = victoriafaldeneName,
                    To = dragebName,
                    Cost = costprsegmentUSD * 3,
                    TimeHours = timeprsegmenthours * 3,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = marrakeshId,
                    toDestinationId = saharaId,
                    From = marrakeshName,
                    To = saharaName,
                    Cost = costprsegmentUSD * 5,
                    TimeHours = timeprsegmenthours * 5,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = sLeoneId,
                    toDestinationId = guldKystId,
                    From = sleoneName,
                    To = guldKystName,
                    Cost = costprsegmentUSD * 5,
                    TimeHours = timeprsegmenthours * 5,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = victoriafaldeneId,
                    toDestinationId = hvalbugtenId,
                    From = victoriafaldeneName,
                    To = hvalbugtenName,
                    Cost = costprsegmentUSD * 4,
                    TimeHours = timeprsegmenthours * 4,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = hvalbugtenId,
                    toDestinationId = kapstadenId,
                    From = hvalbugtenName,
                    To = kapstadenName,
                    Cost = costprsegmentUSD * 4,
                    TimeHours = timeprsegmenthours * 4,
                }
             );

            builder.Entity<Edge>().HasData(
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    fromDestinationId = VictoriaSoeenId,
                    toDestinationId = zanzibarId,
                    From = victoriaSoeenName,
                    To = zanzibarName,
                    Cost = costprsegmentUSD * 5,
                    TimeHours = timeprsegmenthours * 5,
                }
             );

            base.OnModelCreating(builder);
        }
    }
}