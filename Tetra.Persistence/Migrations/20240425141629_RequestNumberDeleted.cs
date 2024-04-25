using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tetra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RequestNumberDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestNumber",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
