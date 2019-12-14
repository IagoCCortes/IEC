using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IEC.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Birthplace = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

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
                name: "MovieRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRoles", x => x.Id);
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
                    Created = table.Column<DateTime>(nullable: false),
                    PosterUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieArtists",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieArtists", x => new { x.MovieId, x.ArtistId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_MovieArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieArtists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieArtists_MovieRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "MovieRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieMovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    MovieGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieGenres", x => new { x.MovieId, x.MovieGenreId });
                    table.ForeignKey(
                        name: "FK_MovieMovieGenres_MovieGenres_MovieGenreId",
                        column: x => x.MovieGenreId,
                        principalTable: "MovieGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieMovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtists_ArtistId",
                table: "MovieArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtists_RoleId",
                table: "MovieArtists",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieGenres_MovieGenreId",
                table: "MovieMovieGenres",
                column: "MovieGenreId");

            var genres = new[] {"Action", "Adventure", "Animation", "Biography", "Comedy", "Crime",
                         "Documentary", "Drama", "Family", "Fantasy", "Film Noir", "History",
                         "Horror", "Music", "Musical", "Mystery", "Romance", "Sci-Fi", "Short Film",
                         "Sport", "Superhero", "Thriller", "War", "Western"};

            var movieMovieGenreRelations = new[] {new [] {1, 6}, new [] {1, 4}, new [] {5, 5}, new [] {5, 6},
                                                   new [] {5, 20}, new [] {6, 2}, new [] {6, 8}, new [] {6, 23},
                                                   new [] {7, 8}, new [] {2, 8}, new [] {8, 1}, new [] {8, 2},
                                                   new [] {8, 8}, new [] {3, 8}, new [] {3, 22}, new [] {4, 8},
                                                   new [] {4, 16}, new [] {4, 18}, new [] {2, 1}, new [] {2, 6},
                                                   new [] {7, 1}, new [] {9, 1}, new [] {9, 18}, new [] {10, 1},
                                                   new [] {10, 8}, new [] {10, 16}};

            var movieRoles = new[] { "Actor", "Director", "Producer", "Writer" };

            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES (\"The Irishman\", \"A mob hitman recalls his possible involvement with the slaying of Jimmy Hoffa.\", \"209\", \"2019-11-27 00:00:00\", \"2019-12-07 22:48:55.512604\", \"https://m.media-amazon.com/images/M/MV5BMGUyM2ZiZmUtMWY0OC00NTQ4LThkOGUtNjY2NjkzMDJiMWMwXkEyXkFqcGdeQXVyMzY0MTE3NzU@._V1_SY1000_CR0,0,682,1000_AL_.jpg\")");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('The Dark Knight', 'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.', '152', '2008-07-18 00:00:00', '2019-12-07 22:49:33.6713224', 'https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('Nocturnal Animals', 'A wealthy art gallery owner is haunted by her ex-husband''s novel, a violent thriller she interprets as a symbolic revenge tale.', '116', '2016-12-09 00:00:00', '2019-12-08 11:35:24.7400989', 'https://m.media-amazon.com/images/M/MV5BMTYwMzMwMzgxNl5BMl5BanBnXkFtZTgwMTA0MTUzMDI@._V1_SX300.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('Arrival', 'A linguist works with the military to communicate with alien lifeforms after twelve mysterious spacecraft appear around the world.', '116', '2016-11-11 00:00:00', '2019-12-08 11:36:29.2556353', 'https://m.media-amazon.com/images/M/MV5BMTExMzU0ODcxNDheQTJeQWpwZ15BbWU4MDE1OTI4MzAy._V1_SY1000_CR0,0,640,1000_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('The Big Lebowski', 'Jeff The Dude Lebowski, mistaken for a millionaire of the same name, seeks restitution for his ruined rug and enlists his bowling buddies to help get it.', '117', '1998-03-06 00:00:00', '2019-12-09 07:39:25.9477905', 'https://m.media-amazon.com/images/M/MV5BMTQ0NjUzMDMyOF5BMl5BanBnXkFtZTgwODA1OTU0MDE@._V1_SY1000_CR0,0,670,1000_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('Inglourious Basterds', 'In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner''s vengeful plans for the same.', '153', '2009-08-21 00:00:00', '2019-12-09 07:43:59.9164132', 'https://m.media-amazon.com/images/M/MV5BOTJiNDEzOWYtMTVjOC00ZjlmLWE0NGMtZmE1OWVmZDQ2OWJhXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SY1000_SX675_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('Pulp Fiction', 'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', '154', '1994-10-14 00:00:00', '2019-12-09 07:50:38.0019123', 'https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('Avengers: Endgame', 'After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos'' actions and restore balance to the universe.', '181', '2019-04-26 00:00:00', '2019-12-09 11:58:44.0270397', 'https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('The Matrix', 'A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.', '136', '1999-03-31', '2019-12-13', 'https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg')");
            migrationBuilder.Sql("INSERT INTO Movies (Title, Plot, Runtime, ReleaseDate, Created, PosterUrl) VALUES ('Blade Runner 2049', 'A young blade runner''s discovery of a long-buried secret leads him to track down former blade runner Rick Deckard, who''s been missing for thirty years.', '166', '2017-10-06 00:00:00', '2019-12-14 08:53:10.4099731', 'https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_SY1000_CR0,0,674,1000_AL_.jpg')");

            foreach (var genre in genres)
            {
                migrationBuilder.Sql($"insert into MovieGenres (Genre) values ('{genre}')");
            }

            foreach (var role in movieRoles)
            {
                migrationBuilder.Sql($"insert into MovieRoles (Role) values ('{role}')");
            }

            foreach (var movieMovieGenre in movieMovieGenreRelations)
            {
                migrationBuilder.Sql($"INSERT INTO MovieMovieGenres VALUES ({movieMovieGenre[0]}, {movieMovieGenre[1]})");
            }

            migrationBuilder.Sql("insert into artists (ArtistName, RealName, Birthdate, Birthplace, Height) values (\"Amy Adams\", \"Amy Lou Adams\", \"1974-08-20 00:00:00\", \"Vicenza, Veneto, Italy\", 163)");
            migrationBuilder.Sql("insert into artists (ArtistName, RealName, Birthdate, Birthplace, Height) values (\"Robert Downey Jr.\", \"Robert John Downey Jr\", \"04/04/1965\", \"Manhattan, New York City, New York, USA\", 174)");
            migrationBuilder.Sql("INSERT INTO Artists (ArtistName, RealName, Birthdate, Birthplace, Height) VALUES ('Keanu Reeves', 'Keanu Charles Reeves', '1964-09-02 00:00:00', 'Beirut, Lebanon', '186')");
            migrationBuilder.Sql("INSERT INTO Artists (ArtistName, RealName, Birthdate, Birthplace, Height) VALUES ('Halle Berry', 'Maria Halle Berry', '1966-08-14 00:00:00', 'Cleveland, Ohio, USA', '166')");
            migrationBuilder.Sql("INSERT INTO Artists (ArtistName) VALUES ('Derek Kolstad')");
            migrationBuilder.Sql("INSERT INTO Artists (ArtistName, RealName, Birthdate, Birthplace, Height) VALUES ('Chad Stahelski', 'Charles F. Stahelski', '1968-09-20 00:00:00', 'USA', '185')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieArtists");

            migrationBuilder.DropTable(
                name: "MovieMovieGenres");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "MovieRoles");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
