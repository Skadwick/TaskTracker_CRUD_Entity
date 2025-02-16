using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker_CRUD.Server.Migrations.RedditComments
{
    /// <inheritdoc />
    public partial class FieldNameUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "RedditComments",
                newName: "Postid");

            migrationBuilder.RenameColumn(
                name: "PermaLink",
                table: "RedditComments",
                newName: "Permalink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postid",
                table: "RedditComments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Permalink",
                table: "RedditComments",
                newName: "PermaLink");
        }
    }
}
