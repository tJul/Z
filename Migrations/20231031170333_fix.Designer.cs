﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SOPlabNEW.Data;

#nullable disable

namespace SOPlabNEW.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20231031170333_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SOPlabNEW.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookHolderId")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookHolderId");

                    b.HasIndex("LibraryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SOPlabNEW.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LibraryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("SOPlabNEW.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SOPlabNEW.Models.Book", b =>
                {
                    b.HasOne("SOPlabNEW.Models.User", "BookHolder")
                        .WithMany("TakenBooks")
                        .HasForeignKey("BookHolderId");

                    b.HasOne("SOPlabNEW.Models.Library", "Library")
                        .WithMany("Books")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookHolder");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("SOPlabNEW.Models.Library", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("SOPlabNEW.Models.User", b =>
                {
                    b.Navigation("TakenBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
