using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gst.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEmFerramentaMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FerramentaXProfissional__cdFerramenta_FK",
                table: "FERRAMENTA_TB");

            migrationBuilder.AlterColumn<int>(
                name: "CDFERRAMENTA",
                table: "FERRAMENTA_TB",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CDPROFISSIONAL",
                table: "FERRAMENTA_TB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FERRAMENTA_TB_CDPROFISSIONAL",
                table: "FERRAMENTA_TB",
                column: "CDPROFISSIONAL");

            migrationBuilder.AddForeignKey(
                name: "FerramentaXProfissional__cdProfissional_FK",
                table: "FERRAMENTA_TB",
                column: "CDPROFISSIONAL",
                principalTable: "PROFISSIONAL_TB",
                principalColumn: "CDPROFISSIONAL",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FerramentaXProfissional__cdProfissional_FK",
                table: "FERRAMENTA_TB");

            migrationBuilder.DropIndex(
                name: "IX_FERRAMENTA_TB_CDPROFISSIONAL",
                table: "FERRAMENTA_TB");

            migrationBuilder.DropColumn(
                name: "CDPROFISSIONAL",
                table: "FERRAMENTA_TB");

            migrationBuilder.AlterColumn<int>(
                name: "CDFERRAMENTA",
                table: "FERRAMENTA_TB",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FerramentaXProfissional__cdFerramenta_FK",
                table: "FERRAMENTA_TB",
                column: "CDFERRAMENTA",
                principalTable: "PROFISSIONAL_TB",
                principalColumn: "CDPROFISSIONAL",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
