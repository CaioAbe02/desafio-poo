using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPOO.Migrations
{
    /// <inheritdoc />
    public partial class AddValorAluguelField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValorAluguel",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorAluguel",
                table: "Apartamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorAluguel",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "ValorAluguel",
                table: "Apartamentos");
        }
    }
}
