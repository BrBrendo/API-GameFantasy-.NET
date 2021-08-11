using Microsoft.EntityFrameworkCore.Migrations;

namespace GameFantasy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaginaTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pagina = table.Column<int>(nullable: true),
                    TamanhoPagina = table.Column<int>(nullable: true),
                    QtdPagina = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaginaTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Pontos = table.Column<int>(nullable: true),
                    PaginaTimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Times_PaginaTimes_PaginaTimeId",
                        column: x => x.PaginaTimeId,
                        principalTable: "PaginaTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Times = table.Column<string>(nullable: true),
                    Placar = table.Column<string>(nullable: true),
                    ViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonatos_ViewModels_ViewModelId",
                        column: x => x.ViewModelId,
                        principalTable: "ViewModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vencedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campeao = table.Column<string>(nullable: true),
                    Vice = table.Column<string>(nullable: true),
                    Terceiro = table.Column<string>(nullable: true),
                    ViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vencedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vencedores_ViewModels_ViewModelId",
                        column: x => x.ViewModelId,
                        principalTable: "ViewModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonatos_ViewModelId",
                table: "Campeonatos",
                column: "ViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Times_PaginaTimeId",
                table: "Times",
                column: "PaginaTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vencedores_ViewModelId",
                table: "Vencedores",
                column: "ViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Vencedores");

            migrationBuilder.DropTable(
                name: "PaginaTimes");

            migrationBuilder.DropTable(
                name: "ViewModels");
        }
    }
}
