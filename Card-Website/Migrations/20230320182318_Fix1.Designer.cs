﻿// <auto-generated />
using System.Collections.Generic;
using Card_Website.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Card_Website.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230320182318_Fix1")]
    partial class Fix1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Card_Website.Models.SimplePost", b =>
                {
                    b.Property<string>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("post_id");

                    b.Property<List<string>>("ImageLinks")
                        .HasColumnType("text[]")
                        .HasColumnName("image_links");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("post_content");

                    b.HasKey("PostId");

                    b.ToTable("SimplePosts");
                });

            modelBuilder.Entity("Card_Website.Models.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("tag_id");

                    b.Property<string>("ParentTagTagId")
                        .HasColumnType("text");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tag_name");

                    b.HasKey("TagId");

                    b.HasIndex("ParentTagTagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SimplePostTag", b =>
                {
                    b.Property<string>("PostsPostId")
                        .HasColumnType("text");

                    b.Property<string>("TagsTagId")
                        .HasColumnType("text");

                    b.HasKey("PostsPostId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("PostTags", (string)null);
                });

            modelBuilder.Entity("Card_Website.Models.Tag", b =>
                {
                    b.HasOne("Card_Website.Models.Tag", "ParentTag")
                        .WithMany()
                        .HasForeignKey("ParentTagTagId");

                    b.Navigation("ParentTag");
                });

            modelBuilder.Entity("SimplePostTag", b =>
                {
                    b.HasOne("Card_Website.Models.SimplePost", null)
                        .WithMany()
                        .HasForeignKey("PostsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Card_Website.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}