﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Translators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreditCardNumberEncrypted = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    OriginalContent = table.Column<string>(type: "TEXT", nullable: false),
                    TranslatedContent = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    TranslatorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationJobs_Translators_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Translators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslationJobs_TranslatorId",
                table: "TranslationJobs",
                column: "TranslatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationJobs");

            migrationBuilder.DropTable(
                name: "Translators");
        }
    }
}
