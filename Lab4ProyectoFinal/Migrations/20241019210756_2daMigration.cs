using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class _2daMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VentasTotales",
                table: "Proveedores",
                newName: "CantidadVentas");

            migrationBuilder.AddColumn<int>(
                name: "DomicilioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TarjetaId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DomicilioId",
                table: "Usuarios",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TarjetaId",
                table: "Usuarios",
                column: "TarjetaId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Domicilio_DomicilioId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MetodoDePagos_TarjetaId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DomicilioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TarjetaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DomicilioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TarjetaId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "CantidadVentas",
                table: "Proveedores",
                newName: "VentasTotales");
        }
    }
}
