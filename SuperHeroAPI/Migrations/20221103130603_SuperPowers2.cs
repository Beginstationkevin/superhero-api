using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroAPI.Migrations
{
    public partial class SuperPowers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_SuperPowers_SuperPowerId",
                table: "SuperHeroes");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_SuperPowerId",
                table: "SuperHeroes");

            migrationBuilder.AlterColumn<int>(
                name: "SuperPowerId",
                table: "SuperHeroes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_SuperPowerId",
                table: "SuperHeroes",
                column: "SuperPowerId",
                unique: true,
                filter: "[SuperPowerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_SuperPowers_SuperPowerId",
                table: "SuperHeroes",
                column: "SuperPowerId",
                principalTable: "SuperPowers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_SuperPowers_SuperPowerId",
                table: "SuperHeroes");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_SuperPowerId",
                table: "SuperHeroes");

            migrationBuilder.AlterColumn<int>(
                name: "SuperPowerId",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
