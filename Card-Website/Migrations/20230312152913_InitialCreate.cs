using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Website.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimplePosts",
                columns: table => new
                {
                    post_id = table.Column<string>(type: "text", nullable: false),
                    post_content = table.Column<string>(type: "text", nullable: false),
                    image_links = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimplePosts", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    tag_id = table.Column<string>(type: "text", nullable: false),
                    ParentTagTagId = table.Column<string>(type: "text", nullable: true),
                    tag_name = table.Column<string>(type: "text", nullable: false),
                    SimplePostPostId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tag_id);
                    table.ForeignKey(
                        name: "FK_Tags_SimplePosts_SimplePostPostId",
                        column: x => x.SimplePostPostId,
                        principalTable: "SimplePosts",
                        principalColumn: "post_id");
                    table.ForeignKey(
                        name: "FK_Tags_Tags_ParentTagTagId",
                        column: x => x.ParentTagTagId,
                        principalTable: "Tags",
                        principalColumn: "tag_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ParentTagTagId",
                table: "Tags",
                column: "ParentTagTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_SimplePostPostId",
                table: "Tags",
                column: "SimplePostPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "SimplePosts");
        }
    }
}
