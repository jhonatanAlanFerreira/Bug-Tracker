using Microsoft.EntityFrameworkCore.Migrations;

namespace bug_tracker.Migrations
{
    public partial class loginTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LogType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nova organização criada" });

            migrationBuilder.InsertData(
                table: "LogType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Login realizado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LogType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LogType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
