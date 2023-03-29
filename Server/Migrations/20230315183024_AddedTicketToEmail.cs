using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailPlanner_Alpha.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedTicketToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Emails_EmailId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EmailId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Emails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_TicketId",
                table: "Emails",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Tickets_TicketId",
                table: "Emails",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Tickets_TicketId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_TicketId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Emails");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmailId",
                table: "Tickets",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Emails_EmailId",
                table: "Tickets",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id");
        }
    }
}
