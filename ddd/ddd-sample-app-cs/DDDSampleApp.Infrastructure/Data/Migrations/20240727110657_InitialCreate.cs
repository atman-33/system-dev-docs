using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDDSampleApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    position = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "todo_types",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    deadline = table.Column<DateTime>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    member_id = table.Column<string>(type: "TEXT", nullable: false),
                    todo_type_id = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.id);
                    table.ForeignKey(
                        name: "FK_todos_members_member_id",
                        column: x => x.member_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_todos_todo_types_todo_type_id",
                        column: x => x.todo_type_id,
                        principalTable: "todo_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "id", "created_at", "name", "position", "updated_at" },
                values: new object[,]
                {
                    { "7531c3df-bfb3-42d1-8eed-5667c890fe44", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2376), "Aさん", "リーダー", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2387) },
                    { "77cebb4f-a8dd-421c-8a08-11eddfefae3f", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2392), "Bさん", "メンバー", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2392) }
                });

            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "74419766-ad87-4baa-a35e-ae06298c3ed9", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2427), "プライベート", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2427) },
                    { "f338175a-544b-4b01-91c1-da79539ad06c", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2442), "仕事", new DateTime(2024, 7, 27, 20, 6, 56, 887, DateTimeKind.Local).AddTicks(2442) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_members_position",
                table: "members",
                column: "position",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_todo_types_name",
                table: "todo_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_todos_member_id",
                table: "todos",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_todos_todo_type_id",
                table: "todos",
                column: "todo_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todos");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "todo_types");
        }
    }
}
