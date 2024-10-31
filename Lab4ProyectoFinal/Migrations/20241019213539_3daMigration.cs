using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class _3daMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Domicilio_DomicilioId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MetodoDePagos_TarjetaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Domicilio",
                table: "Domicilio");

            migrationBuilder.RenameTable(
                name: "Domicilio",
                newName: "Domicilios");

            migrationBuilder.AlterColumn<int>(
                name: "TarjetaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domicilios",
                table: "Domicilios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsuarioDomicilios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DomicilioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDomicilios", x => new { x.UsuarioId, x.DomicilioId });
                    table.ForeignKey(
                        name: "FK_UsuarioDomicilios_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioDomicilios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTarjetas",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTarjetas", x => new { x.UsuarioId, x.TarjetaId });
                    table.ForeignKey(
                        name: "FK_UsuarioTarjetas_MetodoDePagos_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "MetodoDePagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTarjetas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDomicilios_DomicilioId",
                table: "UsuarioDomicilios",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTarjetas_TarjetaId",
                table: "UsuarioTarjetas",
                column: "TarjetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Domicilios_DomicilioId",
                table: "Usuarios",
                column: "DomicilioId",
                principalTable: "Domicilios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_MetodoDePagos_TarjetaId",
                table: "Usuarios",
                column: "TarjetaId",
                principalTable: "MetodoDePagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Domicilios_DomicilioId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MetodoDePagos_TarjetaId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "UsuarioDomicilios");

            migrationBuilder.DropTable(
                name: "UsuarioTarjetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Domicilios",
                table: "Domicilios");

            migrationBuilder.RenameTable(
                name: "Domicilios",
                newName: "Domicilio");

            migrationBuilder.AlterColumn<int>(
                name: "TarjetaId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domicilio",
                table: "Domicilio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Domicilio_DomicilioId",
                table: "Usuarios",
                column: "DomicilioId",
                principalTable: "Domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_MetodoDePagos_TarjetaId",
                table: "Usuarios",
                column: "TarjetaId",
                principalTable: "MetodoDePagos",
                principalColumn: "Id");
        }
    }
}
