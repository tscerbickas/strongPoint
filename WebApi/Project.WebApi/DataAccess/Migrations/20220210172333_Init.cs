using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebApi.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KineticImpatResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    KineticEnergity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KineticImpatResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculationHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    KineticEnergy = table.Column<double>(type: "REAL", precision: 18, scale: 9, nullable: false),
                    Velicoty = table.Column<double>(type: "REAL", nullable: false),
                    Mass = table.Column<double>(type: "REAL", nullable: false),
                    UniqueIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImpactResultId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationHistory_KineticImpatResults_ImpactResultId",
                        column: x => x.ImpactResultId,
                        principalTable: "KineticImpatResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KineticImpatResults",
                columns: new[] { "Id", "Description", "KineticEnergity", "ModifiedDate" },
                values: new object[] { new Guid("13546dc7-fd57-4ab0-a6a7-0b42f69e87da"), "Will not cause any harm.", 0, new DateTime(2022, 2, 10, 19, 23, 33, 811, DateTimeKind.Local).AddTicks(4014) });

            migrationBuilder.InsertData(
                table: "KineticImpatResults",
                columns: new[] { "Id", "Description", "KineticEnergity", "ModifiedDate" },
                values: new object[] { new Guid("9ea9fbad-ba59-4e3c-b8b2-658613e05738"), "Will destroy a whole word.", 10000000, new DateTime(2022, 2, 10, 19, 23, 33, 811, DateTimeKind.Local).AddTicks(4063) });

            migrationBuilder.InsertData(
                table: "KineticImpatResults",
                columns: new[] { "Id", "Description", "KineticEnergity", "ModifiedDate" },
                values: new object[] { new Guid("9fdc51a7-debf-481d-b0f7-b2bca1f2c3fa"), "Will destroy small city.", 10000, new DateTime(2022, 2, 10, 19, 23, 33, 811, DateTimeKind.Local).AddTicks(4058) });

            migrationBuilder.InsertData(
                table: "KineticImpatResults",
                columns: new[] { "Id", "Description", "KineticEnergity", "ModifiedDate" },
                values: new object[] { new Guid("b6e271e9-54d0-46c8-825e-fef8fb8415e5"), "Will destroy a nation.", 1000000, new DateTime(2022, 2, 10, 19, 23, 33, 811, DateTimeKind.Local).AddTicks(4061) });

            migrationBuilder.InsertData(
                table: "KineticImpatResults",
                columns: new[] { "Id", "Description", "KineticEnergity", "ModifiedDate" },
                values: new object[] { new Guid("c52ec09b-688f-4557-aef1-605e29b39f5e"), "Will break the windows.", 1000, new DateTime(2022, 2, 10, 19, 23, 33, 811, DateTimeKind.Local).AddTicks(4055) });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationHistory_ImpactResultId",
                table: "CalculationHistory",
                column: "ImpactResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationHistory");

            migrationBuilder.DropTable(
                name: "KineticImpatResults");
        }
    }
}
