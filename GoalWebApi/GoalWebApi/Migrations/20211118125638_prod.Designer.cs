﻿// <auto-generated />
using System;
using GoalWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoalWebApi.Migrations
{
    [DbContext(typeof(GoalContext))]
    [Migration("20211118125638_prod")]
    partial class prod
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("GoalWebApi.Domain.Entity.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("SysIsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserIdId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserIdId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GoalWebApi.Domain.Entity.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("SysIsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UrlContent")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("GoalWebApi.Domain.Entity.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.Property<bool>("SysIsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoalWebApi.Domain.Entity.Products", b =>
                {
                    b.HasOne("GoalWebApi.Domain.Entity.Users", "UserId")
                        .WithMany()
                        .HasForeignKey("UserIdId");

                    b.Navigation("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}