using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telstar.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "destinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentType",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceModifier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "edges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    TimeHours = table.Column<double>(type: "float", nullable: false),
                    fromDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    toDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_edges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_edges_destinations_fromDestinationId",
                        column: x => x.fromDestinationId,
                        principalTable: "destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_edges_destinations_toDestinationId",
                        column: x => x.toDestinationId,
                        principalTable: "destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weightInKg = table.Column<double>(type: "float", nullable: false),
                    lengthInCm = table.Column<double>(type: "float", nullable: false),
                    widthInCm = table.Column<double>(type: "float", nullable: false),
                    heightInCm = table.Column<double>(type: "float", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalCostInUSD = table.Column<double>(type: "float", nullable: false),
                    paidToOAInUSD = table.Column<double>(type: "float", nullable: false),
                    paidToEICInUSD = table.Column<double>(type: "float", nullable: false),
                    typeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    from = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipments_ShipmentType_typeid",
                        column: x => x.typeid,
                        principalTable: "ShipmentType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "destinations",
                columns: new[] { "Id", "City" },
                values: new object[,]
                {
                    { new Guid("017f584a-c867-494b-809c-f4e2bfa7577e"), "Suakin" },
                    { new Guid("0224c301-4a94-48f6-8df8-f27568583cf4"), "Addis Abeba" },
                    { new Guid("0b6f1334-e14a-4eba-a4a5-dfdd2f3f6bb5"), "Tripoli" },
                    { new Guid("0c7e8374-f30c-4895-bfe9-63f76d424786"), "Timbuktu" },
                    { new Guid("2b102387-95e6-4603-bb33-644352a280ad"), "Mocambique" },
                    { new Guid("400b7f86-7e41-456e-8d78-d80c6fd14160"), "Tanger" },
                    { new Guid("45832d16-eadb-4bbf-b8f1-f2eb6b826d41"), "Kap Guardafui" },
                    { new Guid("4e173e38-3feb-4fbf-b32e-39e7af310aa0"), "Congo" },
                    { new Guid("4ec48c75-d78f-4c52-bdc9-27c81359ad25"), "Tunis" },
                    { new Guid("4f05293d-778b-4344-bf96-eb8be8baafa0"), "Dakar" },
                    { new Guid("5ad64a19-b27a-48b9-95cf-0332e88d7fbf"), "Omdurman" },
                    { new Guid("5b787360-98aa-48ff-b180-2343d1b4a22d"), "Victoria Faldene" },
                    { new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a"), "Darfur" },
                    { new Guid("60b1c48c-4d2e-4a65-bf3b-c9315f23ab27"), "Kabalo" },
                    { new Guid("65c280d6-e9fa-4dd4-8f3c-918aeef28e1b"), "Marrakesh" },
                    { new Guid("6762ac25-184c-45fe-ba68-de1cbfc3a531"), "Wadai" },
                    { new Guid("6ab3d246-2a09-4fbc-bc23-1d3c672c4236"), "Kap St.Marie" },
                    { new Guid("7289b9c0-d3a2-47c4-8ef1-42b761a9071b"), "Sierra Leone" },
                    { new Guid("79feb834-7446-4104-9f21-23892abd6d50"), "Amatave" },
                    { new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), "Victoria Soeen" },
                    { new Guid("84bbf8a7-07e1-41a5-ba00-302d98886fb9"), "Kapstaden" },
                    { new Guid("8d38846e-f4c3-4994-94b8-05e18e221334"), "De Kanariske Oeer" },
                    { new Guid("a32cba22-43d5-44ff-8256-9999d70e3ba0"), "St. Helena" },
                    { new Guid("a8100e5c-42bf-4039-be60-8d5390fecf35"), "Guld kysten" },
                    { new Guid("ac9877b1-d2ba-4cee-b54f-057944515b8b"), "Sahara" },
                    { new Guid("b5c29783-f4e9-4adc-be1d-2dc760865357"), "Cairo" },
                    { new Guid("c67fd119-9dc7-441c-8335-cfced090624b"), "Dragebjerget" },
                    { new Guid("d8409ad5-0806-404f-9c54-b017c969c19c"), "Slavekysten" },
                    { new Guid("db372b4a-782f-444a-8976-a57e0883573a"), "Hvalbugten" },
                    { new Guid("fb3eb190-83c2-4d0b-932d-435e48293013"), "Bahr El Ghazal" },
                    { new Guid("fd6624c4-846b-4d52-adda-b26171edc520"), "Zanzibar" },
                    { new Guid("fdb01392-b9af-4dbb-a6d8-4b5805811377"), "Luanda" }
                });

            migrationBuilder.InsertData(
                table: "edges",
                columns: new[] { "Id", "Cost", "From", "TimeHours", "To", "fromDestinationId", "toDestinationId" },
                values: new object[,]
                {
                    { new Guid("065576fe-00f9-4628-94a5-f93318e7cff4"), 9.0, "Suakin", 12.0, "Addis Abeba", new Guid("017f584a-c867-494b-809c-f4e2bfa7577e"), new Guid("0224c301-4a94-48f6-8df8-f27568583cf4") },
                    { new Guid("0dfb1b66-6dd7-45c6-8391-8220c9c90598"), 30.0, "Luanda", 40.0, "Mocambique", new Guid("fdb01392-b9af-4dbb-a6d8-4b5805811377"), new Guid("2b102387-95e6-4603-bb33-644352a280ad") },
                    { new Guid("290b6f0a-dc8c-4206-89f2-de156f95d57f"), 15.0, "Sierra Leone", 20.0, "Guld kysten", new Guid("7289b9c0-d3a2-47c4-8ef1-42b761a9071b"), new Guid("a8100e5c-42bf-4039-be60-8d5390fecf35") },
                    { new Guid("2bbec322-f6ed-4e45-b6cb-cf9dedb591a9"), 6.0, "Victoria Soeen", 8.0, "Bahr El Ghazal", new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), new Guid("fb3eb190-83c2-4d0b-932d-435e48293013") },
                    { new Guid("388a2eac-952c-4966-899f-edccadaae437"), 24.0, "Marrakesh", 32.0, "Dakar", new Guid("65c280d6-e9fa-4dd4-8f3c-918aeef28e1b"), new Guid("4f05293d-778b-4344-bf96-eb8be8baafa0") },
                    { new Guid("3bbc3281-61ba-481f-ad07-23053ce76a0e"), 12.0, "Kabalo", 16.0, "Luanda", new Guid("60b1c48c-4d2e-4a65-bf3b-c9315f23ab27"), new Guid("fdb01392-b9af-4dbb-a6d8-4b5805811377") },
                    { new Guid("3cd516a1-a5af-4c89-a211-53d23ef59710"), 33.0, "Luanda", 44.0, "Dragebjerget", new Guid("fdb01392-b9af-4dbb-a6d8-4b5805811377"), new Guid("c67fd119-9dc7-441c-8335-cfced090624b") },
                    { new Guid("423b0e35-4ce1-4131-8390-6695ac2cba43"), 21.0, "Slavekysten", 28.0, "Darfur", new Guid("d8409ad5-0806-404f-9c54-b017c969c19c"), new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a") },
                    { new Guid("58ab22fd-14d5-4d79-a355-e7ca1a8a305d"), 15.0, "Slavekysten", 20.0, "Congo", new Guid("d8409ad5-0806-404f-9c54-b017c969c19c"), new Guid("4e173e38-3feb-4fbf-b32e-39e7af310aa0") },
                    { new Guid("5c44fa00-b0a6-4aca-9508-5e9c1342eedb"), 9.0, "Zanzibar", 12.0, "Mocambique", new Guid("fd6624c4-846b-4d52-adda-b26171edc520"), new Guid("2b102387-95e6-4603-bb33-644352a280ad") },
                    { new Guid("5e141a39-3e6e-4c4a-843f-73584a163651"), 15.0, "Victoria Soeen", 20.0, "Zanzibar", new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), new Guid("fd6624c4-846b-4d52-adda-b26171edc520") },
                    { new Guid("608df533-fc33-4e2e-b55a-9a2223e6193b"), 9.0, "Congo", 12.0, "Luanda", new Guid("4e173e38-3feb-4fbf-b32e-39e7af310aa0"), new Guid("fdb01392-b9af-4dbb-a6d8-4b5805811377") },
                    { new Guid("62d503c4-9c9e-4c4c-b065-250d6cfe8493"), 9.0, "Omdurman", 12.0, "Darfur", new Guid("5ad64a19-b27a-48b9-95cf-0332e88d7fbf"), new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a") },
                    { new Guid("685b1668-80f1-455e-b827-d96f929c3d6e"), 18.0, "Tripoli", 24.0, "Omdurman", new Guid("0b6f1334-e14a-4eba-a4a5-dfdd2f3f6bb5"), new Guid("5ad64a19-b27a-48b9-95cf-0332e88d7fbf") },
                    { new Guid("6ad63d91-4068-4500-b83f-551a7a068482"), 15.0, "Sierra Leone", 20.0, "Timbuktu", new Guid("7289b9c0-d3a2-47c4-8ef1-42b761a9071b"), new Guid("0c7e8374-f30c-4895-bfe9-63f76d424786") },
                    { new Guid("73c05528-1095-4685-a477-9a83ea6c85db"), 12.0, "Victoria Soeen", 16.0, "Kabalo", new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), new Guid("60b1c48c-4d2e-4a65-bf3b-c9315f23ab27") },
                    { new Guid("75fa7643-fece-4a5e-8390-bc968de05229"), 12.0, "Mocambique", 16.0, "Dragebjerget", new Guid("2b102387-95e6-4603-bb33-644352a280ad"), new Guid("c67fd119-9dc7-441c-8335-cfced090624b") },
                    { new Guid("769a2bce-c30c-4431-a821-427cc16c32a1"), 15.0, "Sierra Leone", 20.0, "Guld kysten", new Guid("7289b9c0-d3a2-47c4-8ef1-42b761a9071b"), new Guid("a8100e5c-42bf-4039-be60-8d5390fecf35") },
                    { new Guid("77e9252a-612a-4ea1-9080-cd1860ab3480"), 24.0, "Sahara", 32.0, "Darfur", new Guid("ac9877b1-d2ba-4cee-b54f-057944515b8b"), new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a") },
                    { new Guid("7c2d6a65-7d08-4cb8-a69a-3d55a449b777"), 12.0, "Darfur", 16.0, "Wadai", new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a"), new Guid("6762ac25-184c-45fe-ba68-de1cbfc3a531") },
                    { new Guid("7cf6543a-e1a0-4ac0-8125-f3ed3eafa7ea"), 18.0, "Kap Guardafui", 24.0, "Zanzibar", new Guid("45832d16-eadb-4bbf-b8f1-f2eb6b826d41"), new Guid("fd6624c4-846b-4d52-adda-b26171edc520") },
                    { new Guid("7f509e9b-6988-46ea-9a5c-1b6a7376f4d8"), 12.0, "Dakar", 16.0, "Sierra Leone", new Guid("4f05293d-778b-4344-bf96-eb8be8baafa0"), new Guid("7289b9c0-d3a2-47c4-8ef1-42b761a9071b") },
                    { new Guid("86eb5fd7-40a6-480c-b238-f846c1d9ac94"), 15.0, "Mocambique", 20.0, "Victoria Faldene", new Guid("2b102387-95e6-4603-bb33-644352a280ad"), new Guid("5b787360-98aa-48ff-b180-2343d1b4a22d") },
                    { new Guid("879e1562-3f6a-4d5f-9064-dc3c1cdc64de"), 12.0, "Suakin", 16.0, "Darfur", new Guid("017f584a-c867-494b-809c-f4e2bfa7577e"), new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a") },
                    { new Guid("8eb3c0e2-6269-476c-9117-e5cdcfaeea48"), 12.0, "Hvalbugten", 16.0, "Kapstaden", new Guid("db372b4a-782f-444a-8976-a57e0883573a"), new Guid("84bbf8a7-07e1-41a5-ba00-302d98886fb9") },
                    { new Guid("a865dbad-9477-4bc3-bc27-24c848423ad2"), 18.0, "Victoria Faldene", 24.0, "Mocambique", new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), new Guid("2b102387-95e6-4603-bb33-644352a280ad") },
                    { new Guid("acbd2698-31c6-43af-8248-e7935e846336"), 9.0, "Victoria Soeen", 12.0, "Addis Abeba", new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), new Guid("0224c301-4a94-48f6-8df8-f27568583cf4") },
                    { new Guid("b3a885c7-d425-4b0f-a515-f61aeb3daba1"), 12.0, "Omdurman", 16.0, "Cairo", new Guid("5ad64a19-b27a-48b9-95cf-0332e88d7fbf"), new Guid("b5c29783-f4e9-4adc-be1d-2dc760865357") },
                    { new Guid("b56152af-27a9-4b32-8e88-da68a8caeb2d"), 21.0, "Slavekysten", 28.0, "Wadai", new Guid("d8409ad5-0806-404f-9c54-b017c969c19c"), new Guid("6762ac25-184c-45fe-ba68-de1cbfc3a531") },
                    { new Guid("b871f054-205e-4575-aa45-c9b86d7837ec"), 9.0, "Victoria Faldene", 12.0, "Dragebjerget", new Guid("5b787360-98aa-48ff-b180-2343d1b4a22d"), new Guid("c67fd119-9dc7-441c-8335-cfced090624b") },
                    { new Guid("c6e23f2c-0136-4271-94df-b8844dfcef29"), 9.0, "Tunis", 12.0, "Tripoli", new Guid("4ec48c75-d78f-4c52-bdc9-27c81359ad25"), new Guid("0b6f1334-e14a-4eba-a4a5-dfdd2f3f6bb5") },
                    { new Guid("c8c04ae7-be58-4287-8c99-5751dcbfee62"), 15.0, "Timbuktu", 20.0, "Slavekysten", new Guid("0c7e8374-f30c-4895-bfe9-63f76d424786"), new Guid("d8409ad5-0806-404f-9c54-b017c969c19c") },
                    { new Guid("d0fbdc61-7f08-4d88-8868-9a1c50295325"), 15.0, "Tanger", 20.0, "Tunis", new Guid("400b7f86-7e41-456e-8d78-d80c6fd14160"), new Guid("4ec48c75-d78f-4c52-bdc9-27c81359ad25") },
                    { new Guid("d79e1170-8f92-466c-8010-7f3a4fab8f4d"), 6.0, "Darfur", 8.0, "Bahr El Ghazal", new Guid("5e991c00-c1de-45f5-9134-1f6b0267793a"), new Guid("fb3eb190-83c2-4d0b-932d-435e48293013") },
                    { new Guid("de731e77-1f26-4aba-86d7-56e072af6b66"), 6.0, "Tanger", 8.0, "Marrakesh", new Guid("400b7f86-7e41-456e-8d78-d80c6fd14160"), new Guid("65c280d6-e9fa-4dd4-8f3c-918aeef28e1b") },
                    { new Guid("ee59fa6b-471f-48bd-90a0-85f381bf361c"), 12.0, "Victoria Faldene", 16.0, "Hvalbugten", new Guid("5b787360-98aa-48ff-b180-2343d1b4a22d"), new Guid("db372b4a-782f-444a-8976-a57e0883573a") },
                    { new Guid("f1deda79-1952-48a8-9d2c-8c424c49c5ff"), 15.0, "Tanger", 20.0, "Sahara", new Guid("400b7f86-7e41-456e-8d78-d80c6fd14160"), new Guid("ac9877b1-d2ba-4cee-b54f-057944515b8b") },
                    { new Guid("f31800a4-6f0c-4bc3-93db-673108efc8fa"), 9.0, "Addis Abeba", 12.0, "Kap Guardafui", new Guid("0224c301-4a94-48f6-8df8-f27568583cf4"), new Guid("45832d16-eadb-4bbf-b8f1-f2eb6b826d41") },
                    { new Guid("f7d3f6c1-5434-4cb4-bcc9-819d8e77e997"), 15.0, "Marrakesh", 20.0, "Sahara", new Guid("65c280d6-e9fa-4dd4-8f3c-918aeef28e1b"), new Guid("ac9877b1-d2ba-4cee-b54f-057944515b8b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_edges_fromDestinationId",
                table: "edges",
                column: "fromDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_edges_toDestinationId",
                table: "edges",
                column: "toDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_shipments_typeid",
                table: "shipments",
                column: "typeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "edges");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "destinations");

            migrationBuilder.DropTable(
                name: "ShipmentType");
        }
    }
}
