using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaySpace.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalcMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Method = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcMethods", x => x.Id);
                    table.UniqueConstraint("AK_CalcMethods_PostalCode", x => x.PostalCode);
                });

            migrationBuilder.CreateTable(
                name: "ProgressiveTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    To = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressiveTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalcMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calcs_CalcMethods_CalcMethodId",
                        column: x => x.CalcMethodId,
                        principalTable: "CalcMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CalcMethods",
                columns: new[] { "Id", "Method", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("1f3fa8e4-534a-47e2-8a4e-4c3ca769ff9d"), "Progressive", "7441" },
                    { new Guid("dc40403f-7a9c-440d-8e12-0b265cf8c17a"), "FlatValue", "A100" },
                    { new Guid("95f1546d-23a4-4ac5-8ea6-61b3211bc045"), "FlatRate", "7000" },
                    { new Guid("47f53d44-adb8-4fa3-a206-1ee6f960d275"), "Progressive", "1000" }
                });

            migrationBuilder.InsertData(
                table: "ProgressiveTables",
                columns: new[] { "Id", "From", "Rate", "To" },
                values: new object[,]
                {
                    { new Guid("0eded851-88c0-4711-86b4-ed3c09d91d24"), 0m, 0.1m, 8350m },
                    { new Guid("1b2d6b8b-acba-4cbd-99ae-e7b0711d20fe"), 8351m, 0.15m, 33950m },
                    { new Guid("0b78b89b-7ce1-4740-bc36-a6a1c137df08"), 33951m, 0.25m, 82250m },
                    { new Guid("42b8ddcb-c2b1-4f21-9ff7-a1677cab1d59"), 82251m, 0.28m, 171550m },
                    { new Guid("c1e94353-a5eb-405f-9212-634686fddc82"), 171551m, 0.33m, 372950m },
                    { new Guid("7efb5345-fa3f-4dad-b248-164294a90a81"), 372951m, 0.35m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calcs_CalcMethodId",
                table: "Calcs",
                column: "CalcMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calcs");

            migrationBuilder.DropTable(
                name: "ProgressiveTables");

            migrationBuilder.DropTable(
                name: "CalcMethods");
        }
    }
}
