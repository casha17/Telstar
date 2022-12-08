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
                name: "Type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceModifier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
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
                    timestamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalCostInUSD = table.Column<double>(type: "float", nullable: false),
                    paidToOAInUSD = table.Column<double>(type: "float", nullable: false),
                    paidToEICInUSD = table.Column<double>(type: "float", nullable: false),
                    typeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipments_Type_typeid",
                        column: x => x.typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "destinations",
                columns: new[] { "Id", "City" },
                values: new object[,]
                {
                    { new Guid("01d7f120-d7d9-49bc-a506-a80cce326ec5"), "St. Helena" },
                    { new Guid("0224c301-4a94-48f6-8df8-f27568583cf4"), "Addis Abeba" },
                    { new Guid("07318326-2642-488f-8bef-fd14f284535e"), "Dragebjerget" },
                    { new Guid("14f4fcba-bc07-4dab-9dcf-6c78953b3248"), "Tripoli" },
                    { new Guid("156f957a-b6c5-4986-b5ae-3de2f66b272f"), "Timbuktu" },
                    { new Guid("19e528f1-3ad3-4d76-bfd7-72f41bac5f72"), "Luanda" },
                    { new Guid("1b470316-2a4a-4333-b7a2-78b4d9a25957"), "Tanger" },
                    { new Guid("1cd2894a-d5a0-4625-8bc2-0c5490e214e3"), "Amatave" },
                    { new Guid("20807d44-7cf0-4d3e-aca6-3110d5a235da"), "Slavekysten" },
                    { new Guid("46252414-e5e7-4df3-ab22-7e4fe0604cbf"), "Tunis" },
                    { new Guid("5a7a1777-c127-435c-bbb3-7855ff40ae9e"), "Victoria Faldene" },
                    { new Guid("670ba475-8ae7-434b-893c-376ce9a48264"), "Darfur" },
                    { new Guid("74ea4fcf-c9d3-4ee4-9973-4794409ee32e"), "Kabalo" },
                    { new Guid("7765213e-1922-423e-a5ae-da28e4097ac0"), "Bahr El Ghazal" },
                    { new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec"), "Victoria Soeen" },
                    { new Guid("7a81a4a1-e0c8-405e-8352-02f484a8cee2"), "Zanzibar" },
                    { new Guid("7abfb28a-949b-4bb9-bd50-45c04af944a8"), "Sahara" },
                    { new Guid("85bdd99f-e1ec-42d3-8ea3-41a396522dd3"), "Mocambique" },
                    { new Guid("a7f054d5-253a-487b-92cd-59720cad5582"), "Kap St. Marie" },
                    { new Guid("a9033b27-2571-4ce7-95d7-0c7407bbafd5"), "Marrakesh" },
                    { new Guid("ae9bf889-10eb-4cbf-b885-aac0f2cb0194"), "Sierra Leone" },
                    { new Guid("aead90a5-4003-43fc-9045-0a3ae289bb52"), "De Kanariske Oerne" },
                    { new Guid("b65a83f8-2607-4abd-8885-e9c29f20a069"), "Congo" },
                    { new Guid("bb46185e-79e2-47c7-bce1-ffc89a7818e6"), "Hvalbugten" },
                    { new Guid("c0c0ba05-6866-49b1-8523-9a0f62c495ff"), "Dakar" },
                    { new Guid("c51750b7-1323-461c-ac86-7c9bdf56bc2f"), "Cairo" },
                    { new Guid("d39e48cf-c3a3-4ef2-a1c8-aba7a34e0e53"), "Omdurman" },
                    { new Guid("d3cc2d37-7dca-4f08-912c-c3f0155be93d"), "Suakin" },
                    { new Guid("d6c6c34c-b434-4664-a8ec-98919e7e2397"), "Guldkysten" },
                    { new Guid("d6fec231-cdab-484b-abbf-607aca5f7a4b"), "Kap Guardafui" },
                    { new Guid("edf4987f-4dad-46a5-901e-f70d7f149c6c"), "Wadai" },
                    { new Guid("ef2a1edf-fee7-4196-a602-7aa7f3ab2120"), "Kapstaden" }
                });

            migrationBuilder.InsertData(
                table: "edges",
                columns: new[] { "Id", "Cost", "From", "TimeHours", "To", "fromDestinationId", "toDestinationId" },
                values: new object[] { new Guid("a6b804d3-58ac-4870-885d-3a563a64a65d"), 12.0, "Addis Abeba", 12.0, "Victoria Soeen", new Guid("0224c301-4a94-48f6-8df8-f27568583cf4"), new Guid("7a4aee29-b0a5-45db-90dc-3756abc449ec") });

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
                name: "Type");
        }
    }
}
