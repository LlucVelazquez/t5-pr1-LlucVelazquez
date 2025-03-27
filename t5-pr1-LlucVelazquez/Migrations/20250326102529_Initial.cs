using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace t5_pr1_LlucVelazquez.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ProdNeta = table.Column<float>(type: "real", nullable: false),
                    ConsumGasoil = table.Column<float>(type: "real", nullable: false),
                    DemandaElectr = table.Column<float>(type: "real", nullable: false),
                    ProdDisp = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoresSol = table.Column<float>(type: "real", nullable: false),
                    VelocitatVent = table.Column<float>(type: "real", nullable: false),
                    CabalAigua = table.Column<float>(type: "real", nullable: false),
                    Rati = table.Column<float>(type: "real", nullable: false),
                    EnergyGen = table.Column<float>(type: "real", nullable: false),
                    CostTotal = table.Column<float>(type: "real", nullable: false),
                    PreuTotal = table.Column<float>(type: "real", nullable: false),
                    DateT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterConsumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Consume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterConsumes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyIndicators");

            migrationBuilder.DropTable(
                name: "Simulations");

            migrationBuilder.DropTable(
                name: "WaterConsumes");
        }
    }
}
