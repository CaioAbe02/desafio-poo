using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPOO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImovelFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alugado",
                table: "Casas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Casas",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Alugado",
                table: "Apartamentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Apartamentos",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Apartamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alugado",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "Alugado",
                table: "Apartamentos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Apartamentos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Apartamentos");
        }
    }
}
