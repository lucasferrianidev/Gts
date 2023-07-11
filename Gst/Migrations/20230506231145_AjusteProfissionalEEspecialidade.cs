using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gst.Migrations
{
    /// <inheritdoc />
    public partial class AjusteProfissionalEEspecialidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "EnderecoXProfissional__cdEndereco_FK",
                table: "PROFISSIONAL_TB");

            migrationBuilder.AddForeignKey(
                name: "EnderecoXProfissional__cdEndereco_FK",
                table: "PROFISSIONAL_TB",
                column: "CDENDERECO",
                principalTable: "ENDERECO_TB",
                principalColumn: "CDENDERECO",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "EnderecoXProfissional__cdEndereco_FK",
                table: "PROFISSIONAL_TB");

            migrationBuilder.AddForeignKey(
                name: "EnderecoXProfissional__cdEndereco_FK",
                table: "PROFISSIONAL_TB",
                column: "CDENDERECO",
                principalTable: "ENDERECO_TB",
                principalColumn: "CDENDERECO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
