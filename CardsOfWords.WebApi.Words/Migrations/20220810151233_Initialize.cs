using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardsOfWords.WebApi.Words.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RusWord",
                table: "Words",
                newName: "OriginalWord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalWord",
                table: "Words",
                newName: "RusWord");
        }
    }
}
