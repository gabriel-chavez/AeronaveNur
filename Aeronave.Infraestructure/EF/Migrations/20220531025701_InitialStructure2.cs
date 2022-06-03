using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aeronave.Infraestructure.EF.Migrations
{
    public partial class InitialStructure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloAeronave_Aeronave_AeronaveId",
                table: "ModeloAeronave");

            migrationBuilder.DropIndex(
                name: "IX_ModeloAeronave_AeronaveId",
                table: "ModeloAeronave");

            migrationBuilder.DropColumn(
                name: "AeronaveId",
                table: "ModeloAeronave");

            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "ModeloAeronave",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "capacidadCargaCombustible",
                table: "ModeloAeronave",
                newName: "CapacidadCargaCombustible");

            migrationBuilder.RenameColumn(
                name: "capacidadCarga ",
                table: "ModeloAeronave",
                newName: "CapacidadCarga");

            migrationBuilder.RenameColumn(
                name: "observaciones",
                table: "Mantenimiento",
                newName: "Observaciones");

            migrationBuilder.RenameColumn(
                name: "fechaInicio",
                table: "Mantenimiento",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "fechaFin",
                table: "Mantenimiento",
                newName: "FechaFin");

            migrationBuilder.RenameColumn(
                name: "fila",
                table: "Asiento",
                newName: "Fila");

            migrationBuilder.RenameColumn(
                name: "columna",
                table: "Asiento",
                newName: "Columna");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "Asiento",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "matricula",
                table: "Aeronave",
                newName: "Matricula");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Aeronave",
                newName: "Estado");

            migrationBuilder.AddColumn<Guid>(
                name: "AereopuertoId",
                table: "Aeronave",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloAeronaveId",
                table: "Aeronave",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aeronave_AereopuertoId",
                table: "Aeronave",
                column: "AereopuertoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeronave_ModeloAeronaveId",
                table: "Aeronave",
                column: "ModeloAeronaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeronave_Aeropuerto_AereopuertoId",
                table: "Aeronave",
                column: "AereopuertoId",
                principalTable: "Aeropuerto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aeronave_ModeloAeronave_ModeloAeronaveId",
                table: "Aeronave",
                column: "ModeloAeronaveId",
                principalTable: "ModeloAeronave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeronave_Aeropuerto_AereopuertoId",
                table: "Aeronave");

            migrationBuilder.DropForeignKey(
                name: "FK_Aeronave_ModeloAeronave_ModeloAeronaveId",
                table: "Aeronave");

            migrationBuilder.DropIndex(
                name: "IX_Aeronave_AereopuertoId",
                table: "Aeronave");

            migrationBuilder.DropIndex(
                name: "IX_Aeronave_ModeloAeronaveId",
                table: "Aeronave");

            migrationBuilder.DropColumn(
                name: "AereopuertoId",
                table: "Aeronave");

            migrationBuilder.DropColumn(
                name: "ModeloAeronaveId",
                table: "Aeronave");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "ModeloAeronave",
                newName: "modelo");

            migrationBuilder.RenameColumn(
                name: "CapacidadCargaCombustible",
                table: "ModeloAeronave",
                newName: "capacidadCargaCombustible");

            migrationBuilder.RenameColumn(
                name: "CapacidadCarga",
                table: "ModeloAeronave",
                newName: "capacidadCarga ");

            migrationBuilder.RenameColumn(
                name: "Observaciones",
                table: "Mantenimiento",
                newName: "observaciones");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Mantenimiento",
                newName: "fechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "Mantenimiento",
                newName: "fechaFin");

            migrationBuilder.RenameColumn(
                name: "Fila",
                table: "Asiento",
                newName: "fila");

            migrationBuilder.RenameColumn(
                name: "Columna",
                table: "Asiento",
                newName: "columna");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Asiento",
                newName: "area");

            migrationBuilder.RenameColumn(
                name: "Matricula",
                table: "Aeronave",
                newName: "matricula");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Aeronave",
                newName: "estado");

            migrationBuilder.AddColumn<Guid>(
                name: "AeronaveId",
                table: "ModeloAeronave",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModeloAeronave_AeronaveId",
                table: "ModeloAeronave",
                column: "AeronaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloAeronave_Aeronave_AeronaveId",
                table: "ModeloAeronave",
                column: "AeronaveId",
                principalTable: "Aeronave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
