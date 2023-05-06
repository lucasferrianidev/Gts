using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gst.Migrations
{
    /// <inheritdoc />
    public partial class RelacionametoProfissionalEspecialidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NUMERO",
                table: "ENDERECO_TB",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LOGRADOURO",
                table: "ENDERECO_TB",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ESPECIALIDADE_TB",
                columns: table => new
                {
                    CDESPECIALIDADE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Especialidade__cdEspecialidade_PK", x => x.CDESPECIALIDADE);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PROFISSIONAL_ESPECIALIDADE_TB",
                columns: table => new
                {
                    CdProfissionalEspecialidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CDPROFISSIONAL = table.Column<int>(type: "int", nullable: false),
                    CDESPECIALIDADE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProfissionalEspecialidade__cdProfissionalEspecialidade_PK", x => x.CdProfissionalEspecialidade);
                    table.ForeignKey(
                        name: "Especialidade__cdEspecialidade_FK",
                        column: x => x.CDESPECIALIDADE,
                        principalTable: "ESPECIALIDADE_TB",
                        principalColumn: "CDESPECIALIDADE");
                    table.ForeignKey(
                        name: "Profissional__cdProfisional_FK",
                        column: x => x.CDPROFISSIONAL,
                        principalTable: "PROFISSIONAL_TB",
                        principalColumn: "CDPROFISSIONAL");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_ESPECIALIDADE_TB_CDESPECIALIDADE",
                table: "PROFISSIONAL_ESPECIALIDADE_TB",
                column: "CDESPECIALIDADE");

            migrationBuilder.CreateIndex(
                name: "ProfissionalEspecialidade__cdProfissional_cdEspecialidade_IDX",
                table: "PROFISSIONAL_ESPECIALIDADE_TB",
                columns: new[] { "CDPROFISSIONAL", "CDESPECIALIDADE" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROFISSIONAL_ESPECIALIDADE_TB");

            migrationBuilder.DropTable(
                name: "ESPECIALIDADE_TB");

            migrationBuilder.AlterColumn<string>(
                name: "NUMERO",
                table: "ENDERECO_TB",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LOGRADOURO",
                table: "ENDERECO_TB",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
