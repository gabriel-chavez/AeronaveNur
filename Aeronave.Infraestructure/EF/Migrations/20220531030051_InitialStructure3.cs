using Microsoft.EntityFrameworkCore.Migrations;

namespace Aeronave.Infraestructure.EF.Migrations
{
    public partial class InitialStructure3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "marca",
                table: "ModeloAeronave",
                newName: "Marca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "ModeloAeronave",
                newName: "marca");
        }
    }
}
