using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDDSampleApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "todo_types",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "todo_types",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "id", "created_at", "name", "position", "updated_at" },
                values: new object[,]
                {
                    { "6c50e648-bdf3-40e4-ab83-d26da5aca141", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8584), "Bさん", "B", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8585) },
                    { "cae93eb1-f9a1-40ae-908a-683662e76e2d", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8566), "Aさん", "A", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8576) }
                });

            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "456ad9e2-0972-402a-8552-657b96741e70", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8622), "プライベート", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8622) },
                    { "b53edfe0-fd6a-4b87-94b7-7efda8a90ae3", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8628), "仕事", new DateTime(2024, 7, 21, 18, 49, 2, 443, DateTimeKind.Local).AddTicks(8629) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_todo_types_name",
                table: "todo_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_members_position",
                table: "members",
                column: "position",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_todo_types_name",
                table: "todo_types");

            migrationBuilder.DropIndex(
                name: "IX_members_position",
                table: "members");

            migrationBuilder.DeleteData(
                table: "members",
                keyColumn: "id",
                keyValue: "6c50e648-bdf3-40e4-ab83-d26da5aca141");

            migrationBuilder.DeleteData(
                table: "members",
                keyColumn: "id",
                keyValue: "cae93eb1-f9a1-40ae-908a-683662e76e2d");

            migrationBuilder.DeleteData(
                table: "todo_types",
                keyColumn: "id",
                keyValue: "456ad9e2-0972-402a-8552-657b96741e70");

            migrationBuilder.DeleteData(
                table: "todo_types",
                keyColumn: "id",
                keyValue: "b53edfe0-fd6a-4b87-94b7-7efda8a90ae3");

            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "1", null, "プライベート", null },
                    { "2", null, "仕事", null }
                });
        }
    }
}
