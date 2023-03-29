using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailPlanner_Alpha.Server.Migrations
{
    /// <inheritdoc />
    public partial class TicketStartedToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TicketStarted",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "TicketStarted",
                table: "Emails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
