using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo_Sistema",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsCargo = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo_Sistema", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Rotina_Sistema",
                columns: table => new
                {
                    idRotina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsrotina = table.Column<string>(type: "varchar(100)", nullable: true),
                    sistema = table.Column<string>(type: "varchar(50)", nullable: true),                   
                    CargoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotina_Sistema", x => x.idRotina);
                    table.ForeignKey(
                        name: "FK_Rotina_Sistema_Cargo_Sistema_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo_Sistema",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Sistema",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nUsuario = table.Column<string>(type: "varchar(100)", nullable: true),
                    CargoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Sistema", x => x.IdRegistro);
                    table.ForeignKey(
                        name: "FK_Usuario_Sistema_Cargo_Sistema_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo_Sistema",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rotina_Sistema_CargoId",
                table: "Rotina_Sistema",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Sistema_CargoId",
                table: "Usuario_Sistema",
                column: "CargoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rotina_Sistema");

            migrationBuilder.DropTable(
                name: "Usuario_Sistema");

            migrationBuilder.DropTable(
                name: "Cargo_Sistema");
        }
    }
}
