﻿// <auto-generated />
using System;
using Athenathon_Webseite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Athenathon_Webseite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Athenathon_Webseite.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Athenathon_Webseite.Models.UserDistance", b =>
                {
                    b.Property<int>("DistanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AverageSpeed")
                        .HasColumnType("int");

                    b.Property<int>("CaloriesBurned")
                        .HasColumnType("int");

                    b.Property<int>("DayTime")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfSport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DistanceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDistances");
                });

            modelBuilder.Entity("Athenathon_Webseite.Models.UserDistance", b =>
                {
                    b.HasOne("Athenathon_Webseite.Models.User", "User")
                        .WithMany("UserDistances")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Athenathon_Webseite.Models.User", b =>
                {
                    b.Navigation("UserDistances");
                });
#pragma warning restore 612, 618
        }
    }
}
