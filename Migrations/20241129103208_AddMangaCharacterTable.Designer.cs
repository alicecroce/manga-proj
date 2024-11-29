﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using manga_project;

#nullable disable

namespace manga_project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241129103208_AddMangaCharacterTable")]
    partial class AddMangaCharacterTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("manga_project.Domain.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("manga_project.Domain.Manga", b =>
                {
                    b.Property<int>("MangaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MangaId"));

                    b.Property<int>("MagazineId")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MangaId");

                    b.ToTable("Manga");
                });

            modelBuilder.Entity("manga_project.Domain.MangaCharacter", b =>
                {
                    b.Property<int>("MangaCharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MangaCharacterId"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCrossover")
                        .HasColumnType("bit");

                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.HasKey("MangaCharacterId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("MangaId");

                    b.ToTable("MangaCharacter");
                });

            modelBuilder.Entity("manga_project.Domain.MangaCharacter", b =>
                {
                    b.HasOne("manga_project.Domain.Character", "Character")
                        .WithMany("MangaCharacter")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("manga_project.Domain.Manga", "Manga")
                        .WithMany("MangaCharacter")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("manga_project.Domain.Character", b =>
                {
                    b.Navigation("MangaCharacter");
                });

            modelBuilder.Entity("manga_project.Domain.Manga", b =>
                {
                    b.Navigation("MangaCharacter");
                });
#pragma warning restore 612, 618
        }
    }
}