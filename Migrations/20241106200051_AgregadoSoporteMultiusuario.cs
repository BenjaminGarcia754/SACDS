using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SACDS.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoSoporteMultiusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsDonador",
                table: "donadors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsDonador",
                table: "donadors");
        }
    }
}
