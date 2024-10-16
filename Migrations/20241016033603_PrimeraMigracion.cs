using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SACDS.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonacionUrgentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoSanguineoPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonacionUrgentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "donadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipoDonacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiasReposo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoDonacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDonador = table.Column<int>(type: "int", nullable: false),
                    IdTipoDonacion = table.Column<int>(type: "int", nullable: false),
                    IdDonacionUrgente = table.Column<int>(type: "int", nullable: false),
                    FechaDonacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonacionUrgenteId = table.Column<int>(type: "int", nullable: true),
                    DonadorId = table.Column<int>(type: "int", nullable: true),
                    TipoDonacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_DonacionUrgentes_DonacionUrgenteId",
                        column: x => x.DonacionUrgenteId,
                        principalTable: "DonacionUrgentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_donadors_DonadorId",
                        column: x => x.DonadorId,
                        principalTable: "donadors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_tipoDonacions_TipoDonacionId",
                        column: x => x.TipoDonacionId,
                        principalTable: "tipoDonacions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_DonacionUrgenteId",
                table: "Citas",
                column: "DonacionUrgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_DonadorId",
                table: "Citas",
                column: "DonadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_TipoDonacionId",
                table: "Citas",
                column: "TipoDonacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "DonacionUrgentes");

            migrationBuilder.DropTable(
                name: "donadors");

            migrationBuilder.DropTable(
                name: "tipoDonacions");
        }
    }
}
