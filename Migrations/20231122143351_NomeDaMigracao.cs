using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositorioTCC.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tccs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    Orientador = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<string>(type: "TEXT", nullable: false),
                    PalavrasChave = table.Column<string>(type: "TEXT", nullable: false),
                    Resumo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tccs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tccs");
        }
    }
}
