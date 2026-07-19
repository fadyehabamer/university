using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eticket.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActorMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
           name: "ActorMovies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
           name: "ActorMovies",
           columns: table => new
           {
               ActorId = table.Column<int>(nullable: false),
               MovieId = table.Column<int>(nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_ActorMovies", x => new { x.ActorId, x.MovieId });
               table.ForeignKey(
                   name: "FK_ActorMovies_Actors_ActorId",
                   column: x => x.ActorId,
                   principalTable: "Actors",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
               table.ForeignKey(
                   name: "FK_ActorMovies_Movies_MovieId",
                   column: x => x.MovieId,
                   principalTable: "Movies",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
           });
        }
    }

}
