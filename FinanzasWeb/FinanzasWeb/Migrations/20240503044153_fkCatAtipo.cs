using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanzasWeb.Migrations
{
    /// <inheritdoc />
    public partial class fkCatAtipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMovimientoId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_TipoMovimientoId",
                table: "Categorias",
                column: "TipoMovimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_TipoMovimientos_TipoMovimientoId",
                table: "Categorias",
                column: "TipoMovimientoId",
                principalTable: "TipoMovimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_TipoMovimientos_TipoMovimientoId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_TipoMovimientoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "TipoMovimientoId",
                table: "Categorias");
        }
    }
}
