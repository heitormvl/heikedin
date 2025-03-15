using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heikedin.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Curso = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_CPF",
                table: "Forms",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
