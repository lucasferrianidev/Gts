using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gst.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUmPraNEmProfissionalFerramenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
