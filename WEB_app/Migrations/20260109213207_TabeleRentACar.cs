using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Nonu_Stefania_Popa_Raul.Migrations
{
    /// <inheritdoc />
    public partial class TabeleRentACar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Masina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PretPeZi = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Masina_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Inchiriere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasinaID = table.Column<int>(type: "int", nullable: true),
                    NumeClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPreluare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataReturnare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inchiriere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inchiriere_Masina_MasinaID",
                        column: x => x.MasinaID,
                        principalTable: "Masina",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inchiriere_MasinaID",
                table: "Inchiriere",
                column: "MasinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Masina_BrandID",
                table: "Masina",
                column: "BrandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inchiriere");

            migrationBuilder.DropTable(
                name: "Masina");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
