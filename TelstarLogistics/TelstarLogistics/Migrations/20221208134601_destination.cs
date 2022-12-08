using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelstarLogistics.Migrations
{
    public partial class destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("93f6b51e-956a-4200-8f31-80f0b8a75743"));

            migrationBuilder.InsertData(
                table: "destinations",
                columns: new[] { "Id", "City" },
                values: new object[,]
                {
                    { new Guid("1a51d25d-a210-4e13-b5f0-5727618dac9f"), "Dragebjerget" },
                    { new Guid("1d017de4-a03e-42b1-be8d-8a6cd38f59b8"), "Kapstaden" },
                    { new Guid("1d4c8697-5a58-4068-8440-abb339a20218"), "Timbuktu" },
                    { new Guid("217a6aa8-285e-4251-af05-ff67e00cb46c"), "Victoria Faldene" },
                    { new Guid("27b7ce97-2c0a-4cd7-9cc2-b0c22de82ff0"), "St. Helena" },
                    { new Guid("2d92aa27-fa1d-4370-b696-ec1c4cef74a0"), "Addis Abeba" },
                    { new Guid("2fd0c63f-09e5-4874-9c53-73c549f7756c"), "Mocambique" },
                    { new Guid("36a74330-2cd2-43f1-83e0-f6df721f6e04"), "Hvalbugten" },
                    { new Guid("38d7619f-a3a0-4dee-96f9-d91d2a87850c"), "Tripoli" },
                    { new Guid("3d0cdcb3-dcc1-42d2-bb97-45d03c27ae96"), "Luanda" },
                    { new Guid("41be40ef-5686-4d3f-982d-a46cd6038018"), "Bahr El Ghazal" },
                    { new Guid("4b1eba97-0bb7-4a77-ab7c-ff4a65970779"), "Marrakesh" },
                    { new Guid("4c2955fc-6e28-4d54-a8a8-5367d14d2980"), "Sierra Leone" },
                    { new Guid("4d7159bf-ca7d-45d3-9df1-c554d3cd2d2d"), "Tunis" },
                    { new Guid("65701e4c-690f-4402-9642-6c954dd32aa3"), "Dakar" },
                    { new Guid("66988758-9703-4a45-9e51-97ac19551089"), "Zanzibar" },
                    { new Guid("69d5ed64-2fc5-40a0-9fe7-949d7a5a7211"), "Guldkysten" },
                    { new Guid("710eb3ad-7015-4721-9296-6ad77af82f16"), "Sahara" },
                    { new Guid("732f7c8e-fd41-45b8-ac20-8cd51cc8d5f6"), "Congo" },
                    { new Guid("7ac1e6a5-8178-4ed5-bd4f-61854f7ea8ca"), "Slavekysten" },
                    { new Guid("7ccebbfa-dbf1-4f8e-ae2d-a5e8279b70a8"), "Kap Guardafui" },
                    { new Guid("81e6086b-2a18-463d-8af0-2015f70fc881"), "Cairo" },
                    { new Guid("8b273f19-f6da-4898-a92a-c43cba2ea0c9"), "Amatave" },
                    { new Guid("9a601cdd-cdec-47bc-9d7f-62ccd038f12b"), "Suakin" },
                    { new Guid("a9ae4624-f69f-4671-8cfe-382cb4063c77"), "Omdurman" },
                    { new Guid("b9416791-4f9e-4515-8480-be716746c938"), "Wadai" },
                    { new Guid("b99b020a-6614-4028-abab-7b41009dc0e7"), "Tanger" },
                    { new Guid("c6415afa-4d75-4980-84a0-8c751b5ea962"), "Darfur" },
                    { new Guid("c7bbe187-a0ff-4618-a848-dc283ab0f998"), "Kabalo" },
                    { new Guid("da469bc5-6017-4ff0-9acb-bab10e0c11e3"), "Victoria Soeen" },
                    { new Guid("f2621e52-025e-43ab-bc8f-1984453b9efc"), "Kap St. Marie" },
                    { new Guid("f8780aa3-70ff-470c-b73d-d7158236dcf0"), "De Kanariske Oeyer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("1a51d25d-a210-4e13-b5f0-5727618dac9f"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("1d017de4-a03e-42b1-be8d-8a6cd38f59b8"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("1d4c8697-5a58-4068-8440-abb339a20218"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("217a6aa8-285e-4251-af05-ff67e00cb46c"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("27b7ce97-2c0a-4cd7-9cc2-b0c22de82ff0"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("2d92aa27-fa1d-4370-b696-ec1c4cef74a0"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("2fd0c63f-09e5-4874-9c53-73c549f7756c"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("36a74330-2cd2-43f1-83e0-f6df721f6e04"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("38d7619f-a3a0-4dee-96f9-d91d2a87850c"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("3d0cdcb3-dcc1-42d2-bb97-45d03c27ae96"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("41be40ef-5686-4d3f-982d-a46cd6038018"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("4b1eba97-0bb7-4a77-ab7c-ff4a65970779"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("4c2955fc-6e28-4d54-a8a8-5367d14d2980"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("4d7159bf-ca7d-45d3-9df1-c554d3cd2d2d"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("65701e4c-690f-4402-9642-6c954dd32aa3"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("66988758-9703-4a45-9e51-97ac19551089"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("69d5ed64-2fc5-40a0-9fe7-949d7a5a7211"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("710eb3ad-7015-4721-9296-6ad77af82f16"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("732f7c8e-fd41-45b8-ac20-8cd51cc8d5f6"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("7ac1e6a5-8178-4ed5-bd4f-61854f7ea8ca"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("7ccebbfa-dbf1-4f8e-ae2d-a5e8279b70a8"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("81e6086b-2a18-463d-8af0-2015f70fc881"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("8b273f19-f6da-4898-a92a-c43cba2ea0c9"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("9a601cdd-cdec-47bc-9d7f-62ccd038f12b"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("a9ae4624-f69f-4671-8cfe-382cb4063c77"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("b9416791-4f9e-4515-8480-be716746c938"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("b99b020a-6614-4028-abab-7b41009dc0e7"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("c6415afa-4d75-4980-84a0-8c751b5ea962"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("c7bbe187-a0ff-4618-a848-dc283ab0f998"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("da469bc5-6017-4ff0-9acb-bab10e0c11e3"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("f2621e52-025e-43ab-bc8f-1984453b9efc"));

            migrationBuilder.DeleteData(
                table: "destinations",
                keyColumn: "Id",
                keyValue: new Guid("f8780aa3-70ff-470c-b73d-d7158236dcf0"));

            migrationBuilder.InsertData(
                table: "destinations",
                columns: new[] { "Id", "City" },
                values: new object[] { new Guid("93f6b51e-956a-4200-8f31-80f0b8a75743"), "Tripoli" });
        }
    }
}
