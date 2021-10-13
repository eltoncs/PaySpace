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
                    Rate = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
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
