using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_tickets_app_webapi.WebApi.Shared.Database.Migrations
{
    public partial class CreateTableTheaterRoomAddTheaterRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheaterRoom",
                schema: "MovieTicketApp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TheaterId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheaterRoom_Theater_TheaterId",
                        column: x => x.TheaterId,
                        principalSchema: "MovieTicketApp",
                        principalTable: "Theater",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheaterRoom_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom",
                column: "TheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheaterRoom",
                schema: "MovieTicketApp");
        }
    }
}
