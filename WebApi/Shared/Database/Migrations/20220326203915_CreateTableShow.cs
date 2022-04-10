using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_tickets_app_webapi.WebApi.Shared.Database.Migrations
{
    public partial class CreateTableShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom");

            migrationBuilder.AlterColumn<long>(
                name: "TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Show",
                schema: "MovieTicketApp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    TheaterRoomId = table.Column<long>(type: "bigint", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Show_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "MovieTicketApp",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Show_TheaterRoom_TheaterRoomId",
                        column: x => x.TheaterRoomId,
                        principalSchema: "MovieTicketApp",
                        principalTable: "TheaterRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Show_MovieId",
                schema: "MovieTicketApp",
                table: "Show",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_TheaterRoomId",
                schema: "MovieTicketApp",
                table: "Show",
                column: "TheaterRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom",
                column: "TheaterId",
                principalSchema: "MovieTicketApp",
                principalTable: "Theater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom");

            migrationBuilder.DropTable(
                name: "Show",
                schema: "MovieTicketApp");

            migrationBuilder.AlterColumn<long>(
                name: "TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom",
                column: "TheaterId",
                principalSchema: "MovieTicketApp",
                principalTable: "Theater",
                principalColumn: "Id");
        }
    }
}
