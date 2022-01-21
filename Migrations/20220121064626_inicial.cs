using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesAPI.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Series",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Duracao",
                table: "Series",
                newName: "Ano");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Series",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Series",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Series");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Series",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Series",
                newName: "Duracao");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Series",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
