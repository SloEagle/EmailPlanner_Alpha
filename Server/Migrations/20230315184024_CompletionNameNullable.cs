using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailPlanner_Alpha.Server.Migrations
{
    /// <inheritdoc />
    public partial class CompletionNameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Completion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Completion",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Completion",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Completion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
