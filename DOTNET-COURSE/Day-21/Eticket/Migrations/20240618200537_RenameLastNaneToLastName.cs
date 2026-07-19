using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eticket.Migrations
{
    /// <inheritdoc />
    public partial class RenameLastNaneToLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastNane",
                table: "Actors",
                newName: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Actors",
                newName: "LastNane");
        }
    }
}
