﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PreventDeskTool;

namespace PreventDeskTool.Migrations
{
    [DbContext(typeof(PreventDeskToolDBContext))]
    partial class PreventDeskToolDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PreventDeskTool.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("MessageBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChatId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("PreventDeskTool.Models.GameProgress", b =>
                {
                    b.Property<int>("ProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProgressId");

                    b.ToTable("GameProgress");
                });

            modelBuilder.Entity("PreventDeskTool.Models.GameProgressDetail", b =>
                {
                    b.Property<int>("GameProgressDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameProgressVideoId")
                        .HasColumnType("int");

                    b.Property<int>("OptionValue")
                        .HasColumnType("int");

                    b.HasKey("GameProgressDetailId");

                    b.ToTable("GameProgressDetail");
                });

            modelBuilder.Entity("PreventDeskTool.Models.GameProgressVideo", b =>
                {
                    b.Property<int>("GameProgressVideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProgressId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("GameProgressVideoId");

                    b.ToTable("GameProgressVideo");
                });

            modelBuilder.Entity("PreventDeskTool.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemember")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PreventDeskTool.Models.VideoMcQs", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OptionPercentage")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.Property<int?>("VideosVideoId")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("VideosVideoId");

                    b.ToTable("VideoMCQs");
                });

            modelBuilder.Entity("PreventDeskTool.Models.Videos", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DifficultyCategory")
                        .HasColumnType("int");

                    b.Property<string>("VideoMcQsTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoSize")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("PreventDeskTool.Models.VideoMcQs", b =>
                {
                    b.HasOne("PreventDeskTool.Models.Videos", null)
                        .WithMany("VideoMcQsOptions")
                        .HasForeignKey("VideosVideoId");
                });

            modelBuilder.Entity("PreventDeskTool.Models.Videos", b =>
                {
                    b.Navigation("VideoMcQsOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
