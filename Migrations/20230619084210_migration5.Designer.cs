﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestMaster2;

#nullable disable

namespace TestMaster2.Migrations
{
    [DbContext(typeof(ProvasContext))]
    [Migration("20230619084210_migration5")]
    partial class migration5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("TestMaster2.Models.Alternativa", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Certo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("QuestaoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

                    b.ToTable("tb_alternativa", (string)null);
                });

            modelBuilder.Entity("TestMaster2.Models.Aluno", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AlunosId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("MateriaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AlunosId");

                    b.HasIndex("MateriaId");

                    b.ToTable("tb_aluno", (string)null);
                });

            modelBuilder.Entity("TestMaster2.Models.Materia", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AlunosId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProfessorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("tb_materia", (string)null);
                });

            modelBuilder.Entity("TestMaster2.Models.Professor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("tb_professor", (string)null);
                });

            modelBuilder.Entity("TestMaster2.Models.Prova", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MateriaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<DateTime>("Prazo")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("tb_prova", (string)null);
                });

            modelBuilder.Entity("TestMaster2.Models.Questao", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<int?>("ProvaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvaId");

                    b.ToTable("tb_questao", (string)null);
                });

            modelBuilder.Entity("TestMaster2.Models.Alternativa", b =>
                {
                    b.HasOne("TestMaster2.Models.Questao", "Questao")
                        .WithMany()
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("TestMaster2.Models.Aluno", b =>
                {
                    b.HasOne("TestMaster2.Models.Materia", null)
                        .WithMany("Alunos")
                        .HasForeignKey("AlunosId");

                    b.HasOne("TestMaster2.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("TestMaster2.Models.Materia", b =>
                {
                    b.HasOne("TestMaster2.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("TestMaster2.Models.Prova", b =>
                {
                    b.HasOne("TestMaster2.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("TestMaster2.Models.Questao", b =>
                {
                    b.HasOne("TestMaster2.Models.Prova", "Prova")
                        .WithMany()
                        .HasForeignKey("ProvaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prova");
                });

            modelBuilder.Entity("TestMaster2.Models.Materia", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
