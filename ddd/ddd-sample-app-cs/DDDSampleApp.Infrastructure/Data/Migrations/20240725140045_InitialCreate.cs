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
                    { "63f1d2f1-12a6-45c2-b48e-fa4a81b6484e", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(962), "Bさん", "メンバー", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(962) },
                    { "ca9e97df-e931-49cb-93f1-926f96902c02", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(936), "Aさん", "リーダー", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(956) }
                });

            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "2624aa01-fc01-451e-9022-7725105f9689", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(1132), "プライベート", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(1134) },
                    { "38226631-23b7-4b80-ac5d-e5aad89b11c4", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(1138), "仕事", new DateTime(2024, 7, 25, 23, 0, 44, 930, DateTimeKind.Local).AddTicks(1139) }
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
