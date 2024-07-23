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
                    { "73e9bafb-80ea-4829-9e93-eabe999d0b9d", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2497), "Bさん", "メンバー", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2498) },
                    { "89fb5db5-5222-4fac-9ac2-452d81a654f9", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2472), "Aさん", "リーダー", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2482) }
                });

            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "7347956e-cb5f-4657-8548-be2c1c40bdf2", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2538), "仕事", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2538) },
                    { "931b3142-78b0-4680-a733-fd659d58b7e7", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2532), "プライベート", new DateTime(2024, 7, 23, 23, 19, 9, 618, DateTimeKind.Local).AddTicks(2533) }
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
