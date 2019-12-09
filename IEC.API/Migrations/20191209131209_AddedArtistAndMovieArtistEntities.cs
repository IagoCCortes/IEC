using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IEC.API.Migrations
{
    public partial class AddedArtistAndMovieArtistEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(nullable: false),
                    RealName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Birthplace = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Bio = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieArtist",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieArtist", x => new { x.MovieId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_MovieArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieArtist_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtist_ArtistId",
                table: "MovieArtist",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieArtist");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
