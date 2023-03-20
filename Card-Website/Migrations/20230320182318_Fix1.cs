using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Website.Migrations
{
    /// <inheritdoc />
    public partial class Fix1 : Migration
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
                    tag_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tag_id);
                    table.ForeignKey(
                        name: "FK_Tags_Tags_ParentTagTagId",
                        column: x => x.ParentTagTagId,
                        principalTable: "Tags",
                        principalColumn: "tag_id");
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostsPostId = table.Column<string>(type: "text", nullable: false),
                    TagsTagId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostsPostId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_PostTags_SimplePosts_PostsPostId",
                        column: x => x.PostsPostId,
                        principalTable: "SimplePosts",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagsTagId",
                table: "PostTags",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ParentTagTagId",
                table: "Tags",
                column: "ParentTagTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "SimplePosts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
