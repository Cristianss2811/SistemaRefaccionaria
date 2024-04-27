using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaRefaccionaria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaPuestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TipoPuesto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puestos");
        }
    }
}
