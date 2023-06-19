using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMaster2.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_aluno_tb_materia_MateriaId",
                table: "tb_aluno");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "tb_aluno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aluno_tb_materia_MateriaId",
                table: "tb_aluno",
                column: "MateriaId",
                principalTable: "tb_materia",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_aluno_tb_materia_MateriaId",
                table: "tb_aluno");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "tb_aluno",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_aluno_tb_materia_MateriaId",
                table: "tb_aluno",
                column: "MateriaId",
                principalTable: "tb_materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
