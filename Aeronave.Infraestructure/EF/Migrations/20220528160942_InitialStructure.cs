using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aeronave.Infraestructure.EF.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    matricula = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Aeronave_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModeloAeronave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    capacidadCarga = table.Column<decimal>(name: "capacidadCarga ", type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    capacidadCargaCombustible = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloAeronave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloAeronave_Aeronave_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asiento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fila = table.Column<int>(type: "int", nullable: false),
                    columna = table.Column<int>(type: "int", nullable: false),
                    area = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModeloAeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asiento_ModeloAeronave_ModeloAeronaveId",
                        column: x => x.ModeloAeronaveId,
                        principalTable: "ModeloAeronave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asiento_ModeloAeronaveId",
                table: "Asiento",
                column: "ModeloAeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_AeronaveId",
                table: "Mantenimiento",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloAeronave_AeronaveId",
                table: "ModeloAeronave",
                column: "AeronaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeropuerto");

            migrationBuilder.DropTable(
                name: "Asiento");

            migrationBuilder.DropTable(
                name: "Mantenimiento");

            migrationBuilder.DropTable(
                name: "ModeloAeronave");

            migrationBuilder.DropTable(
                name: "Aeronave");
        }
    }
}
