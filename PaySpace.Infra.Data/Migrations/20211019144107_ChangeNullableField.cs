using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaySpace.Infra.Data.Migrations
{
    public partial class ChangeNullableField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("0a20c85c-0cc0-4d0e-89ec-d55ba1bd58e3"));

            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("52b9e2b5-a1a5-423b-b9bd-7e68b96de035"));

            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("79e252a9-8d27-4fc7-85b6-287e02392935"));

            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("dd0c3a96-f8e8-458c-aee4-3721e97147a3"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("09163b3d-300c-4982-8f07-080964b137be"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("0da43645-2560-48d2-90f4-d45813727b74"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("2db15f47-25cd-4ea6-82f8-152e3477afad"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("478c8a36-635c-4866-aa79-24f67de02594"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("8933dce0-5a23-48ef-afe1-7a90038930dd"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("e31b887f-74fb-4b3a-a560-9ea9ff8f4680"));

            migrationBuilder.AlterColumn<decimal>(
                name: "To",
                table: "ProgressiveTables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CalcMethods",
                columns: new[] { "Id", "Method", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("ec06f78a-d3af-47f1-b5b2-bc2244dee534"), "Progressive", "7441" },
                    { new Guid("2b30e2a3-0649-4b05-8843-4b938a305bbe"), "FlatValue", "A100" },
                    { new Guid("34a41012-9070-4a72-a6e1-bf0df62d7062"), "FlatRate", "7000" },
                    { new Guid("5d4d3ce2-5897-4af9-a568-ec6faecd9249"), "Progressive", "1000" }
                });

            migrationBuilder.InsertData(
                table: "ProgressiveTables",
                columns: new[] { "Id", "From", "Rate", "To" },
                values: new object[,]
                {
                    { new Guid("1c9b871c-4f0f-46dd-89e8-5d01a5979d71"), 0m, 0.1m, 8350m },
                    { new Guid("a3ecdcbb-e76c-4252-8944-8280db5e23c8"), 8351m, 0.15m, 33950m },
                    { new Guid("9a89699a-7409-4dc2-a2a0-c1ac40f82e21"), 33951m, 0.25m, 82250m },
                    { new Guid("a0635549-d327-45cf-9f38-ff782452d571"), 82251m, 0.28m, 171550m },
                    { new Guid("dc677896-95cb-4805-8b9a-f36d4cdd28c1"), 171551m, 0.33m, 372950m },
                    { new Guid("ec3ad822-02fd-4dd0-878c-ed738b8ba596"), 372951m, 0.35m, 99999999999999m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("2b30e2a3-0649-4b05-8843-4b938a305bbe"));

            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("34a41012-9070-4a72-a6e1-bf0df62d7062"));

            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("5d4d3ce2-5897-4af9-a568-ec6faecd9249"));

            migrationBuilder.DeleteData(
                table: "CalcMethods",
                keyColumn: "Id",
                keyValue: new Guid("ec06f78a-d3af-47f1-b5b2-bc2244dee534"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("1c9b871c-4f0f-46dd-89e8-5d01a5979d71"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("9a89699a-7409-4dc2-a2a0-c1ac40f82e21"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("a0635549-d327-45cf-9f38-ff782452d571"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("a3ecdcbb-e76c-4252-8944-8280db5e23c8"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("dc677896-95cb-4805-8b9a-f36d4cdd28c1"));

            migrationBuilder.DeleteData(
                table: "ProgressiveTables",
                keyColumn: "Id",
                keyValue: new Guid("ec3ad822-02fd-4dd0-878c-ed738b8ba596"));

            migrationBuilder.AlterColumn<decimal>(
                name: "To",
                table: "ProgressiveTables",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "CalcMethods",
                columns: new[] { "Id", "Method", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("0a20c85c-0cc0-4d0e-89ec-d55ba1bd58e3"), "Progressive", "7441" },
                    { new Guid("79e252a9-8d27-4fc7-85b6-287e02392935"), "FlatValue", "A100" },
                    { new Guid("52b9e2b5-a1a5-423b-b9bd-7e68b96de035"), "FlatRate", "7000" },
                    { new Guid("dd0c3a96-f8e8-458c-aee4-3721e97147a3"), "Progressive", "1000" }
                });

            migrationBuilder.InsertData(
                table: "ProgressiveTables",
                columns: new[] { "Id", "From", "Rate", "To" },
                values: new object[,]
                {
                    { new Guid("8933dce0-5a23-48ef-afe1-7a90038930dd"), 0m, 0.1m, 8350m },
                    { new Guid("09163b3d-300c-4982-8f07-080964b137be"), 8351m, 0.15m, 33950m },
                    { new Guid("e31b887f-74fb-4b3a-a560-9ea9ff8f4680"), 33951m, 0.25m, 82250m },
                    { new Guid("478c8a36-635c-4866-aa79-24f67de02594"), 82251m, 0.28m, 171550m },
                    { new Guid("0da43645-2560-48d2-90f4-d45813727b74"), 171551m, 0.33m, 372950m },
                    { new Guid("2db15f47-25cd-4ea6-82f8-152e3477afad"), 372951m, 0.35m, 99999999999999m }
                });
        }
    }
}
