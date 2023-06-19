using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMaster2.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunosId",
                table: "tb_materia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlunosId",
                table: "tb_aluno",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "tb_aluno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_prova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Prazo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Peso = table.Column<double>(type: "double", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_prova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_prova_tb_materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "tb_materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_questao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<double>(type: "double", nullable: false),
                    ProvaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_questao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_questao_tb_prova_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "tb_prova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_alternativa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Certo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alternativa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_alternativa_tb_questao_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "tb_questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aluno_AlunosId",
                table: "tb_aluno",
                column: "AlunosId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aluno_MateriaId",
                table: "tb_aluno",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_alternativa_QuestaoId",
                table: "tb_alternativa",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_prova_MateriaId",
                table: "tb_prova",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_questao_ProvaId",
                table: "tb_questao",
                column: "ProvaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aluno_tb_materia_AlunosId",
                table: "tb_aluno",
                column: "AlunosId",
                principalTable: "tb_materia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aluno_tb_materia_MateriaId",
                table: "tb_aluno",
                column: "MateriaId",
                principalTable: "tb_materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_aluno_tb_materia_AlunosId",
                table: "tb_aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_aluno_tb_materia_MateriaId",
                table: "tb_aluno");

            migrationBuilder.DropTable(
                name: "tb_alternativa");

            migrationBuilder.DropTable(
                name: "tb_questao");

            migrationBuilder.DropTable(
                name: "tb_prova");

            migrationBuilder.DropIndex(
                name: "IX_tb_aluno_AlunosId",
                table: "tb_aluno");

            migrationBuilder.DropIndex(
                name: "IX_tb_aluno_MateriaId",
                table: "tb_aluno");

            migrationBuilder.DropColumn(
                name: "AlunosId",
                table: "tb_materia");

            migrationBuilder.DropColumn(
                name: "AlunosId",
                table: "tb_aluno");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "tb_aluno");
        }
    }
}
