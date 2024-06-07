using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaVinciGlobal.Migrations
{
    /// <inheritdoc />
    public partial class Editando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_DV_RELATORIO_TB_DV_USUARIO_UsuarioId",
                table: "TB_DV_RELATORIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_DV_RELATORIO_UsuarioId",
                table: "TB_DV_RELATORIO");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_DV_RELATORIO");

            migrationBuilder.AlterColumn<double>(
                name: "vl_temperatura_minima",
                table: "TB_DV_RELATORIO",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<double>(
                name: "vl_temperatura_media",
                table: "TB_DV_RELATORIO",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<double>(
                name: "vl_temperatura_maxima",
                table: "TB_DV_RELATORIO",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "vl_temperatura_minima",
                table: "TB_DV_RELATORIO",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "vl_temperatura_media",
                table: "TB_DV_RELATORIO",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "vl_temperatura_maxima",
                table: "TB_DV_RELATORIO",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_DV_RELATORIO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_RELATORIO_UsuarioId",
                table: "TB_DV_RELATORIO",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_DV_RELATORIO_TB_DV_USUARIO_UsuarioId",
                table: "TB_DV_RELATORIO",
                column: "UsuarioId",
                principalTable: "TB_DV_USUARIO",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
