using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaVinciGlobal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DV_SENSOR",
                columns: table => new
                {
                    id_sensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_SENSOR", x => x.id_sensor);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_USUARIO",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_USUARIO", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_DADO_TEMPERATURA",
                columns: table => new
                {
                    id_dado_temperatura = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_coleta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    vl_temperatura = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_DADO_TEMPERATURA", x => x.id_dado_temperatura);
                    table.ForeignKey(
                        name: "FK_TB_DV_DADO_TEMPERATURA_TB_DV_SENSOR_SensorId",
                        column: x => x.SensorId,
                        principalTable: "TB_DV_SENSOR",
                        principalColumn: "id_sensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_IMAGEM_CORAL",
                columns: table => new
                {
                    id_imagem_coral = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_caminho_imagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_envio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ds_estado_coral = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_IMAGEM_CORAL", x => x.id_imagem_coral);
                    table.ForeignKey(
                        name: "FK_TB_DV_IMAGEM_CORAL_TB_DV_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_DV_USUARIO",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_RELATORIO",
                columns: table => new
                {
                    id_relatorio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    dt_fim = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ds_localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    vl_temperatura_media = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    vl_temperatura_maxima = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    vl_temperatura_minima = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_RELATORIO", x => x.id_relatorio);
                    table.ForeignKey(
                        name: "FK_TB_DV_RELATORIO_TB_DV_SENSOR_SensorId",
                        column: x => x.SensorId,
                        principalTable: "TB_DV_SENSOR",
                        principalColumn: "id_sensor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_DV_RELATORIO_TB_DV_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_DV_USUARIO",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_DADO_TEMPERATURA_SensorId",
                table: "TB_DV_DADO_TEMPERATURA",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_IMAGEM_CORAL_UsuarioId",
                table: "TB_DV_IMAGEM_CORAL",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_RELATORIO_SensorId",
                table: "TB_DV_RELATORIO",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_RELATORIO_UsuarioId",
                table: "TB_DV_RELATORIO",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DV_DADO_TEMPERATURA");

            migrationBuilder.DropTable(
                name: "TB_DV_IMAGEM_CORAL");

            migrationBuilder.DropTable(
                name: "TB_DV_RELATORIO");

            migrationBuilder.DropTable(
                name: "TB_DV_SENSOR");

            migrationBuilder.DropTable(
                name: "TB_DV_USUARIO");
        }
    }
}
