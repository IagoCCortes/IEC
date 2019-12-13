using Microsoft.EntityFrameworkCore.Migrations;

namespace IEC.API.Migrations
{
    public partial class AddedMovieRoleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "MovieArtist",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtist_RoleId",
                table: "MovieArtist",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieArtist_MovieRoles_RoleId",
                table: "MovieArtist",
                column: "RoleId",
                principalTable: "MovieRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieArtist_MovieRoles_RoleId",
                table: "MovieArtist");

            migrationBuilder.DropTable(
                name: "MovieRoles");

            migrationBuilder.DropIndex(
                name: "IX_MovieArtist_RoleId",
                table: "MovieArtist");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "MovieArtist");
        }
    }
}
