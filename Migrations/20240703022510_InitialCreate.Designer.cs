﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoQuarry.Models;

#nullable disable

namespace ToDoQuarry.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20240703022510_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToDoQuarry.TodoItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean")
                        .HasColumnName("iscomplete");

                    b.Property<DateOnly>("dueDate")
                        .HasColumnType("date")
                        .HasColumnName("duedate");

                    b.Property<string>("priority")
                        .HasColumnType("text")
                        .HasColumnName("priority");

                    b.Property<string>("taskName")
                        .HasColumnType("text")
                        .HasColumnName("taskname");

                    b.HasKey("ID");

                    b.ToTable("todolist");
                });
#pragma warning restore 612, 618
        }
    }
}