﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodleBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class authin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CivilId",
                table: "UserAccounts",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserAccounts",
                newName: "CivilId");
        }
    }
}
