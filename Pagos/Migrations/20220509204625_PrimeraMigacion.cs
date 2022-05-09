using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Pagos.Migrations
{
    public partial class PrimeraMigacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fPagoContribAseldeps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoAsegurado = table.Column<string>(type: "text", nullable: true),
                    tipoIdentificacion = table.Column<string>(type: "text", nullable: true),
                    nroIdentificacion = table.Column<int>(type: "integer", nullable: false),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    nuaCua = table.Column<int>(type: "integer", nullable: false),
                    periodoCotizacion = table.Column<string>(type: "text", nullable: true),
                    fechaPago = table.Column<string>(type: "text", nullable: true),
                    perfilEdad = table.Column<string>(type: "text", nullable: true),
                    primerApellido = table.Column<string>(type: "text", nullable: true),
                    segundoApellido = table.Column<string>(type: "text", nullable: true),
                    apellidoCasada = table.Column<string>(type: "text", nullable: true),
                    primerNombre = table.Column<string>(type: "text", nullable: true),
                    segundoNombre = table.Column<string>(type: "text", nullable: true),
                    departamento = table.Column<string>(type: "text", nullable: true),
                    provincia = table.Column<string>(type: "text", nullable: true),
                    ciudad = table.Column<string>(type: "text", nullable: true),
                    Zona = table.Column<string>(type: "text", nullable: true),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    nroVivienda = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    telCel = table.Column<int>(type: "integer", nullable: false),
                    lugarPago = table.Column<string>(type: "text", nullable: true),
                    nroAportesPagar = table.Column<int>(type: "integer", nullable: false),
                    formaPago = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fPagoContribAseldeps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fPagoContribAseldeps");
        }
    }
}
