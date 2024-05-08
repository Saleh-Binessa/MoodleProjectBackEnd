using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodleBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class addedtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminEntity_UserAccounts_UserAccountId",
                table: "AdminEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminEntity",
                table: "AdminEntity");

            migrationBuilder.RenameTable(
                name: "AdminEntity",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_AdminEntity_UserAccountId",
                table: "Admins",
                newName: "IX_Admins_UserAccountId");

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_UserAccounts_UserAccountId",
                table: "Admins",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_UserAccounts_UserAccountId",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "AdminEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_UserAccountId",
                table: "AdminEntity",
                newName: "IX_AdminEntity_UserAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminEntity",
                table: "AdminEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEntity_UserAccounts_UserAccountId",
                table: "AdminEntity",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
