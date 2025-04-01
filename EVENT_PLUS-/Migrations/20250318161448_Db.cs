using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Plus.Migrations
{
    /// <inheritdoc />
    public partial class Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    InstituicaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.InstituicaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    TipoUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.TipoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    DescricaoEvento = table.Column<string>(type: "TEXT", nullable: false),
                    TipoEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituicaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "InstituicaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_TipoEvento_TipoEventoId",
                        column: x => x.TipoEventoId,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    SenhaUsuario = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TipoUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "TipoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComentarioEvento = table.Column<string>(type: "TEXT", nullable: false),
                    EXibirComentario = table.Column<bool>(type: "BIT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioEventoId);
                    table.ForeignKey(
                        name: "FK_Comentario_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    PresencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.PresencaId);
                    table.ForeignKey(
                        name: "FK_Presenca_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_EventoId",
                table: "Comentario",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_EXibirComentario",
                table: "Comentario",
                column: "EXibirComentario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioId",
                table: "Comentario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_InstituicaoId",
                table: "Evento",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TipoEventoId",
                table: "Evento",
                column: "TipoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_EventoId",
                table: "Presenca",
                column: "EventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioId",
                table: "Presenca",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmailUsuario",
                table: "Usuario",
                column: "EmailUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
