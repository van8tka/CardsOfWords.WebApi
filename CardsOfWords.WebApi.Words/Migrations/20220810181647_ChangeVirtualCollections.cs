using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardsOfWords.WebApi.Words.Migrations
{
    public partial class ChangeVirtualCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "WordGroups",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordGroups_LanguageId",
                table: "WordGroups",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordGroups_Languages_LanguageId",
                table: "WordGroups",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordGroups_Languages_LanguageId",
                table: "WordGroups");

            migrationBuilder.DropIndex(
                name: "IX_WordGroups_LanguageId",
                table: "WordGroups");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "WordGroups");
        }
    }
}
