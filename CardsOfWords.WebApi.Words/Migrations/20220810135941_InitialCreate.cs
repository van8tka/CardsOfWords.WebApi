using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardsOfWords.WebApi.Words.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "WordGroups",
                newName: "IdLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_WordGroups_LanguageId",
                table: "WordGroups",
                newName: "IX_WordGroups_IdLanguage");

            migrationBuilder.AlterColumn<string>(
                name: "TranslateWord",
                table: "Words",
                type: "character varying(650)",
                maxLength: 650,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Transcription",
                table: "Words",
                type: "character varying(650)",
                maxLength: 650,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RusWord",
                table: "Words",
                type: "character varying(650)",
                maxLength: 650,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WordGroups",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "AppVersions",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationName",
                table: "AppVersions",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_WordGroups_Languages_IdLanguage",
                table: "WordGroups",
                column: "IdLanguage",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordGroups_IdWordGroup",
                table: "Words",
                column: "IdWordGroup",
                principalTable: "WordGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordGroups_Languages_IdLanguage",
                table: "WordGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordGroups_IdWordGroup",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "IdWordGroup",
                table: "Words",
                newName: "WordGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_IdWordGroup",
                table: "Words",
                newName: "IX_Words_WordGroupId");

            migrationBuilder.RenameColumn(
                name: "IdLanguage",
                table: "WordGroups",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_WordGroups_IdLanguage",
                table: "WordGroups",
                newName: "IX_WordGroups_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "TranslateWord",
                table: "Words",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(650)",
                oldMaxLength: 650);

            migrationBuilder.AlterColumn<string>(
                name: "Transcription",
                table: "Words",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(650)",
                oldMaxLength: 650);

            migrationBuilder.AlterColumn<string>(
                name: "RusWord",
                table: "Words",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(650)",
                oldMaxLength: 650);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WordGroups",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "AppVersions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationName",
                table: "AppVersions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

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
    }
}
