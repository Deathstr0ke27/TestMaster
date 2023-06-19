using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMaster2.Migrations
{
    /// <inheritdoc />
    public partial class migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_aluno_materia",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aluno_materia", x => new { x.AlunoId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_tb_aluno_materia_tb_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "tb_aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_aluno_materia_tb_materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "tb_materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aluno_materia_MateriaId",
                table: "tb_aluno_materia",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_aluno_materia");
        }
    }
}
