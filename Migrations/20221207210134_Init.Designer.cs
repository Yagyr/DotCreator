﻿// <auto-generated />
using LamartTest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LamartTest.Migrations
{
    [DbContext(typeof(PointsDbContext))]
    [Migration("20221207210134_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LamartTest.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BackgroundColor = "null",
                            PointId = 1,
                            Text = "Comment 1"
                        },
                        new
                        {
                            Id = 2,
                            BackgroundColor = "Yellow",
                            PointId = 1,
                            Text = "Comment 2"
                        },
                        new
                        {
                            Id = 3,
                            BackgroundColor = "null",
                            PointId = 2,
                            Text = "Comment 3"
                        });
                });

            modelBuilder.Entity("LamartTest.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Radius")
                        .HasColumnType("int");

                    b.Property<int>("XPos")
                        .HasColumnType("int");

                    b.Property<int>("YPos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Points");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Yellow",
                            Radius = 50,
                            XPos = 500,
                            YPos = 80
                        },
                        new
                        {
                            Id = 2,
                            Color = "Green",
                            Radius = 20,
                            XPos = 800,
                            YPos = 150
                        });
                });

            modelBuilder.Entity("LamartTest.Models.Comment", b =>
                {
                    b.HasOne("LamartTest.Models.Point", null)
                        .WithMany("CommentsUnderPoint")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LamartTest.Models.Point", b =>
                {
                    b.Navigation("CommentsUnderPoint");
                });
#pragma warning restore 612, 618
        }
    }
}
