using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardsOfWords.WebApi.Words.Migrations
{
    public partial class ChangeForKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordGroups_Languages_IdLanguage",
                table: "WordGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_WordGroups_Languages_LanguageId",
                table: "WordGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordGroups_IdWordGroup",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_WordGroups_IdLanguage",
                table: "WordGroups");

            migrationBuilder.DropColumn(
                name: "IdLanguage",
                table: "WordGroups");

            migrationBuilder.RenameColumn(
                name: "IdWordGroup",
                table: "Words",
                newName: "WordGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_IdWordGroup",
                table: "Words",
                newName: "IX_Words_WordGroupId");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "WordGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WordGroups_Languages_LanguageId",
                table: "WordGroups",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordGroups_WordGroupId",
                table: "Words",
                column: "WordGroupId",
                principalTable: "WordGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordGroups_Languages_LanguageId",
                table: "WordGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordGroups_WordGroupId",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "WordGroupId",
                table: "Words",
                newName: "IdWordGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Words_WordGroupId",
                table: "Words",
                newName: "IX_Words_IdWordGroup");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "WordGroups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdLanguage",
                table: "WordGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WordGroups_IdLanguage",
                table: "WordGroups",
                column: "IdLanguage");

            migrationBuilder.AddForeignKey(
                name: "FK_WordGroups_Languages_IdLanguage",
                table: "WordGroups",
                column: "IdLanguage",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordGroups_Languages_LanguageId",
                table: "WordGroups",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordGroups_IdWordGroup",
                table: "Words",
                column: "IdWordGroup",
                principalTable: "WordGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
