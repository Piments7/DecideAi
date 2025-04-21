using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecideAi.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    MotivoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Motivo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Buraco = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    ILuminacaoPublica = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    LixoNaoColetado = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    Outros = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.MotivoId);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EnderecoLocal = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Cep = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MotivoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Motivo_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "Motivo",
                        principalColumn: "MotivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacao_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motivo_Buraco",
                table: "Motivo",
                column: "Buraco",
                unique: true,
                filter: "\"Buraco\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Motivo_ILuminacaoPublica",
                table: "Motivo",
                column: "ILuminacaoPublica",
                unique: true,
                filter: "\"ILuminacaoPublica\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Motivo_LixoNaoColetado",
                table: "Motivo",
                column: "LixoNaoColetado",
                unique: true,
                filter: "\"LixoNaoColetado\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Motivo_Outros",
                table: "Motivo",
                column: "Outros",
                unique: true,
                filter: "\"Outros\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_MotivoId",
                table: "Solicitacao",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_UsuarioId",
                table: "Solicitacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Motivo");
        }
    }
}
