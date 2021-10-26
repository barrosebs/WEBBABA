using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BABA.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    AtletaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Apelido = table.Column<string>(type: "TEXT", nullable: true),
                    Camisa = table.Column<int>(type: "INTEGER", nullable: false),
                    Posicao = table.Column<int>(type: "INTEGER", nullable: false),
                    Comissao = table.Column<bool>(type: "INTEGER", nullable: false),
                    WhatsApp = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.AtletaId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Mensalidades",
                columns: table => new
                {
                    MensalidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorPrincipal = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorPagamento = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorSaldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EhQuitada = table.Column<bool>(type: "INTEGER", nullable: false),
                    AtletaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensalidades", x => x.MensalidadeId);
                    table.ForeignKey(
                        name: "FK_Mensalidades_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "AtletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Controles",
                columns: table => new
                {
                    ControleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    ehAtleta = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MensalidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controles", x => x.ControleId);
                    table.ForeignKey(
                        name: "FK_Controles_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Controles_Mensalidades_MensalidadeId",
                        column: x => x.MensalidadeId,
                        principalTable: "Mensalidades",
                        principalColumn: "MensalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controles_CategoriaId",
                table: "Controles",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Controles_MensalidadeId",
                table: "Controles",
                column: "MensalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidades_AtletaId",
                table: "Mensalidades",
                column: "AtletaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Mensalidades");

            migrationBuilder.DropTable(
                name: "Atletas");
        }
    }
}
