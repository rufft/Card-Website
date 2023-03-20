using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Website.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_SimplePosts_PostsPostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Tags_TagsTagId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "image_links",
                table: "SimplePosts");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "SimplePostTag");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagsTagId",
                table: "SimplePostTag",
                newName: "IX_SimplePostTag_TagsTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimplePostTag",
                table: "SimplePostTag",
                columns: new[] { "PostsPostId", "TagsTagId" });

            migrationBuilder.CreateTable(
                name: "ImageLinks",
                columns: table => new
                {
                    image_link_id = table.Column<string>(type: "text", nullable: false),
                    image_link = table.Column<string>(type: "text", nullable: false),
                    SimplePostPostId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLinks", x => x.image_link_id);
                    table.ForeignKey(
                        name: "FK_ImageLinks_SimplePosts_SimplePostPostId",
                        column: x => x.SimplePostPostId,
                        principalTable: "SimplePosts",
                        principalColumn: "post_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageLinks_SimplePostPostId",
                table: "ImageLinks",
                column: "SimplePostPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimplePostTag_SimplePosts_PostsPostId",
                table: "SimplePostTag",
                column: "PostsPostId",
                principalTable: "SimplePosts",
                principalColumn: "post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SimplePostTag_Tags_TagsTagId",
                table: "SimplePostTag",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimplePostTag_SimplePosts_PostsPostId",
                table: "SimplePostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_SimplePostTag_Tags_TagsTagId",
                table: "SimplePostTag");

            migrationBuilder.DropTable(
                name: "ImageLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimplePostTag",
                table: "SimplePostTag");

            migrationBuilder.RenameTable(
                name: "SimplePostTag",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_SimplePostTag_TagsTagId",
                table: "PostTags",
                newName: "IX_PostTags_TagsTagId");

            migrationBuilder.AddColumn<List<string>>(
                name: "image_links",
                table: "SimplePosts",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostsPostId", "TagsTagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_SimplePosts_PostsPostId",
                table: "PostTags",
                column: "PostsPostId",
                principalTable: "SimplePosts",
                principalColumn: "post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Tags_TagsTagId",
                table: "PostTags",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
