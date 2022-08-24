using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    IDDrzave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDrzave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.IDDrzave);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    SifraProizvoda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivModela = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.SifraProizvoda);
                });

            migrationBuilder.CreateTable(
                name: "Trziste",
                columns: table => new
                {
                    SifraTrzista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTrzista = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trziste", x => x.SifraTrzista);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false),
                    IDDrzave = table.Column<int>(type: "int", nullable: false),
                    NazivGrada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => new { x.PostanskiBroj, x.IDDrzave });
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_IDDrzave",
                        column: x => x.IDDrzave,
                        principalTable: "Drzava",
                        principalColumn: "IDDrzave",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Karakteristika",
                columns: table => new
                {
                    IDKarakteristike = table.Column<int>(type: "int", nullable: false),
                    SifraProizvoda = table.Column<int>(type: "int", nullable: false),
                    Vrednost = table.Column<double>(type: "float", nullable: false),
                    NazivKarakteristike = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karakteristika", x => new { x.IDKarakteristike, x.SifraProizvoda });
                    table.ForeignKey(
                        name: "FK_Karakteristika_Proizvod_SifraProizvoda",
                        column: x => x.SifraProizvoda,
                        principalTable: "Proizvod",
                        principalColumn: "SifraProizvoda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdgovornoLice",
                columns: table => new
                {
                    SifraRadnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SifraTrzista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdgovornoLice", x => x.SifraRadnika);
                    table.ForeignKey(
                        name: "FK_OdgovornoLice_Trziste_SifraTrzista",
                        column: x => x.SifraTrzista,
                        principalTable: "Trziste",
                        principalColumn: "SifraTrzista");
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    PIB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKupca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UlicaBroj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDDrzave = table.Column<int>(type: "int", nullable: false),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.PIB);
                    table.ForeignKey(
                        name: "FK_Kupac_Grad",
                        columns: x => new { x.PostanskiBroj, x.IDDrzave },
                        principalTable: "Grad",
                        principalColumns: new[] { "PostanskiBroj", "IDDrzave" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_IDDrzave",
                table: "Grad",
                column: "IDDrzave");

            migrationBuilder.CreateIndex(
                name: "IX_Karakteristika_SifraProizvoda",
                table: "Karakteristika",
                column: "SifraProizvoda");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_PostanskiBroj_IDDrzave",
                table: "Kupac",
                columns: new[] { "PostanskiBroj", "IDDrzave" });

            migrationBuilder.CreateIndex(
                name: "IX_OdgovornoLice_SifraTrzista",
                table: "OdgovornoLice",
                column: "SifraTrzista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karakteristika");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "OdgovornoLice");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Trziste");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
