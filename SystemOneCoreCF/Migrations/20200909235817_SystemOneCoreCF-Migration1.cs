using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemOneCoreCF.Migrations
{
    public partial class SystemOneCoreCFMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    idcategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    estado = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.idcategoria);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    idproducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idcategoria = table.Column<int>(nullable: false),
                    codigo = table.Column<string>(unicode: false, maxLength: 105, nullable: false),
                    nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    precio_venta = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    stock = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    estado = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.idproducto);
                    table.ForeignKey(
                        name: "FK_producto_categoria",
                        column: x => x.idcategoria,
                        principalTable: "categoria",
                        principalColumn: "idcategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_producto_idcategoria",
                table: "producto",
                column: "idcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_producto_nombre",
                table: "producto",
                column: "nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
