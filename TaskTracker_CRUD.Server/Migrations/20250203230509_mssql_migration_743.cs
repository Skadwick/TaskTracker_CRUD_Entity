using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker_CRUD.Server.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_743 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Examples",
                table: "Examples");

            migrationBuilder.RenameTable(
                name: "Examples",
                newName: "TrackedTasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackedTasks",
                table: "TrackedTasks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackedTasks",
                table: "TrackedTasks");

            migrationBuilder.RenameTable(
                name: "TrackedTasks",
                newName: "Examples");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examples",
                table: "Examples",
                column: "Id");
        }
    }
}
