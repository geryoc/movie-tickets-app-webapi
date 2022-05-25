using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_tickets_app_webapi.WebApi.Shared.Database.Migrations
{
    public partial class ChangeFKsOnDeleteCascadeToOnDeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genre_GenreId",
                schema: "MovieTicketApp",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_MovieId",
                schema: "MovieTicketApp",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_TheaterRoom_TheaterRoomId",
                schema: "MovieTicketApp",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_GenreId",
                schema: "MovieTicketApp",
                table: "Movie",
                column: "GenreId",
                principalSchema: "MovieTicketApp",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_MovieId",
                schema: "MovieTicketApp",
                table: "Show",
                column: "MovieId",
                principalSchema: "MovieTicketApp",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_TheaterRoom_TheaterRoomId",
                schema: "MovieTicketApp",
                table: "Show",
                column: "TheaterRoomId",
                principalSchema: "MovieTicketApp",
                principalTable: "TheaterRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom",
                column: "TheaterId",
                principalSchema: "MovieTicketApp",
                principalTable: "Theater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genre_GenreId",
                schema: "MovieTicketApp",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_MovieId",
                schema: "MovieTicketApp",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_TheaterRoom_TheaterRoomId",
                schema: "MovieTicketApp",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_TheaterRoom_Theater_TheaterId",
                schema: "MovieTicketApp",
                table: "TheaterRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_GenreId",
                schema: "MovieTicketApp",
                table: "Movie",
                column: "GenreId",
                principalSchema: "MovieTicketApp",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_MovieId",
                schema: "MovieTicketApp",
                table: "Show",
                column: "MovieId",
                principalSchema: "MovieTicketApp",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_TheaterRoom_TheaterRoomId",
                schema: "MovieTicketApp",
                table: "Show",
                column: "TheaterRoomId",
                principalSchema: "MovieTicketApp",
                principalTable: "TheaterRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
