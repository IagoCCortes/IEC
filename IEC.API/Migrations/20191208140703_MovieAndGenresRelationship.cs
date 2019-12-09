using Microsoft.EntityFrameworkCore.Migrations;

namespace IEC.API.Migrations
{
    public partial class MovieAndGenresRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_MovieMovieGenres_MovieGenreId",
                table: "MovieMovieGenres",
                column: "MovieGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieMovieGenres");
        }
    }
}
