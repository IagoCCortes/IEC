using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IEC.API.Migrations
{
    public partial class AddedMoviesAndMovieGenresEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            var genres = new [] {"Action", "Adventure", "Animation", "Biography", "Comedy", "Crime", "Documentary", 
                                 "Drama", "Family", "Fantasy", "Film Noir", "History", "Horror", "Music", "Musical", 
                                 "Mystery", "Romance", "Sci-Fi", "Short Film", "Sport", "Superhero", "Thriller", "War", "Western"};

            foreach(var genre in genres)
                migrationBuilder.InsertData("MovieGenres", "Genre", genre);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
