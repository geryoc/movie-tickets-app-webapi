using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_tickets_app_webapi.WebApi.Shared.Database.Migrations
{
    public partial class CreateTheaterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Theater",
                schema: "MovieTicketApp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Theater",
                schema: "MovieTicketApp");
        }
    }
}
