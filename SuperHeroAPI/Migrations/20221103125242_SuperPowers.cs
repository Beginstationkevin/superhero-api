using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroAPI.Migrations
{
    public partial class SuperPowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuperPowerId",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SuperPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_SuperPowerId",
                table: "SuperHeroes",
                column: "SuperPowerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_SuperPowers_SuperPowerId",
                table: "SuperHeroes",
                column: "SuperPowerId",
                principalTable: "SuperPowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_SuperPowers_SuperPowerId",
                table: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "SuperPowers");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_SuperPowerId",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "SuperPowerId",
                table: "SuperHeroes");
        }
    }
}
