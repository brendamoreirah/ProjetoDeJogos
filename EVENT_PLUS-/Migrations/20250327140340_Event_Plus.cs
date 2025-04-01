using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Plus.Migrations
{
    /// <inheritdoc />
    public partial class Event_Plus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EXibirComentario",
                table: "Comentario",
                newName: "ExibirComentario");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_EXibirComentario",
                table: "Comentario",
                newName: "IX_Comentario_ExibirComentario");

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Instituicao",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Comentario",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "ExibirComentario",
                table: "Comentario",
                newName: "EXibirComentario");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_ExibirComentario",
                table: "Comentario",
                newName: "IX_Comentario_EXibirComentario");

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Instituicao",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");
        }
    }
}
