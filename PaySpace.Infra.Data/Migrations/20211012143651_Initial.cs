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
                    { new Guid("ddc46bcc-b484-4356-a1e0-69163fc8c4f9"), "Progressive", "7441" },
                    { new Guid("e3561787-3d2c-41fe-9be2-31a1a9ac4761"), "FlatValue", "A100" },
                    { new Guid("21a56700-2b33-45a2-b2b0-95d9ad45ff80"), "FlatRate", "7000" },
                    { new Guid("6d3000b7-eac4-4505-be32-1c5f4b6ff899"), "Progressive", "1000" }
                });

            migrationBuilder.InsertData(
                table: "ProgressiveTables",
                columns: new[] { "Id", "From", "Rate", "To" },
                values: new object[,]
                {
                    { new Guid("cb813e0f-5e3c-4223-8afe-4805bccd0f61"), 0m, 0.1m, 8350m },
                    { new Guid("7fc9e398-c867-41f2-adf0-628bf7960a07"), 8351m, 0.15m, 33950m },
                    { new Guid("6a0d5a8a-1d03-4972-8e7f-a6e764a5f89f"), 33951m, 0.25m, 82250m },
                    { new Guid("a066fb2b-daff-4b24-a0a4-4b987089bedf"), 82251m, 0.28m, 171550m },
                    { new Guid("d9b1c7b9-c737-4888-9fc8-2a602bd6985e"), 171551m, 0.33m, 372950m },
                    { new Guid("fd84aad0-83c6-4241-a06e-9c15f42ff8ed"), 372951m, 0.35m, null }
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
