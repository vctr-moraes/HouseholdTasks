using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdTasks.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeResponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsavel",
                table: "Tarefas");

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ResponsavelId",
                table: "Tarefas",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Responsaveis_ResponsavelId",
                table: "Tarefas",
                column: "ResponsavelId",
                principalTable: "Responsaveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Responsaveis_ResponsavelId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ResponsavelId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "Responsavel",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
