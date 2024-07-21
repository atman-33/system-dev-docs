using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDDSampleApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTodoTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "1", null, "プライベート", null },
                    { "2", null, "仕事", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "todo_types",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "todo_types",
                keyColumn: "id",
                keyValue: "2");
        }
    }
}
