using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailPlanner_Alpha.Server.Migrations
{
    /// <inheritdoc />
    public partial class TicketStartedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TicketStarted",
                table: "Emails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketStarted",
                table: "Emails");
        }
    }
}
