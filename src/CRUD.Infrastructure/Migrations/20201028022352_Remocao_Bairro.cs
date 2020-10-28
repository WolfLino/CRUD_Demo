using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Infrastructure.Migrations
{
    public partial class Remocao_Bairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Wallets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Wallets",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
