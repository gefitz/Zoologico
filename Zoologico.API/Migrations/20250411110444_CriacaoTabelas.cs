using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoologico.API.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dthNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cuidados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCuidado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalModelCuidadoModel",
                columns: table => new
                {
                    Animaisid = table.Column<int>(type: "int", nullable: false),
                    Cuidadosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalModelCuidadoModel", x => new { x.Animaisid, x.Cuidadosid });
                    table.ForeignKey(
                        name: "FK_AnimalModelCuidadoModel_Animais_Animaisid",
                        column: x => x.Animaisid,
                        principalTable: "Animais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalModelCuidadoModel_Cuidados_Cuidadosid",
                        column: x => x.Cuidadosid,
                        principalTable: "Cuidados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalModelCuidadoModel_Cuidadosid",
                table: "AnimalModelCuidadoModel",
                column: "Cuidadosid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalModelCuidadoModel");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Cuidados");
        }
    }
}
