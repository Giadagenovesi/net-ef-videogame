using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "SoftwareHouses");

            migrationBuilder.CreateTable(
                name: "SoftwareHouse",
                columns: table => new
                {
                    SoftwareHouseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareHouse", x => x.SoftwareHouseId);
                });

            migrationBuilder.CreateTable(
                name: "Videogame",
                columns: table => new
                {
                    VideogameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftwareHouseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogame", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_Videogame_SoftwareHouse_SoftwareHouseId",
                        column: x => x.SoftwareHouseId,
                        principalTable: "SoftwareHouse",
                        principalColumn: "SoftwareHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videogame_SoftwareHouseId",
                table: "Videogame",
                column: "SoftwareHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videogame");

            migrationBuilder.DropTable(
                name: "SoftwareHouse");

            migrationBuilder.CreateTable(
                name: "SoftwareHouses",
                columns: table => new
                {
                    SoftwareHousesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareHouses", x => x.SoftwareHousesId);
                });

            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    VideogamesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareHousesId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftwareHouseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.VideogamesId);
                    table.ForeignKey(
                        name: "FK_Videogames_SoftwareHouses_SoftwareHousesId",
                        column: x => x.SoftwareHousesId,
                        principalTable: "SoftwareHouses",
                        principalColumn: "SoftwareHousesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_SoftwareHousesId",
                table: "Videogames",
                column: "SoftwareHousesId");
        }
    }
}
