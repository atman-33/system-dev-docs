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
                    { "90f77859-d713-46d9-9a82-8bb21bd66256", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3417), "Aさん", "リーダー", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3431) },
                    { "a11711e1-c2f1-41e9-a0d3-cc76464ff77d", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3435), "Bさん", "メンバー", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3436) }
                });

            migrationBuilder.InsertData(
                table: "todo_types",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { "728014d6-96c1-4020-901e-61a541ea3967", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3481), "プライベート", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3481) },
                    { "78920b8b-ae53-44e5-8c99-d17dffe67790", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3484), "仕事", new DateTime(2024, 8, 7, 21, 57, 51, 86, DateTimeKind.Local).AddTicks(3485) }
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
