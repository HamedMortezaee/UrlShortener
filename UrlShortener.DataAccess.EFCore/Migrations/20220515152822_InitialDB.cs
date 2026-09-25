using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.DataAccess.EFCore.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlShortener",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlShortenerGUID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MainUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortestUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlShortener", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrlShortenerHistoryEnity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlShortenerId = table.Column<long>(type: "bigint", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlShortenerHistoryEnity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrlShortenerHistoryEnity_UrlShortener_UrlShortenerId",
                        column: x => x.UrlShortenerId,
                        principalTable: "UrlShortener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlShortenerHistoryEnity_UrlShortenerId",
                table: "UrlShortenerHistoryEnity",
                column: "UrlShortenerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlShortenerHistoryEnity");

            migrationBuilder.DropTable(
                name: "UrlShortener");
        }
    }
}
