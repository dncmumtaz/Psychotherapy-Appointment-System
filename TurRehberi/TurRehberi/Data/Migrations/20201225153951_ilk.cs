using Microsoft.EntityFrameworkCore.Migrations;

namespace TurRehberi.Data.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.CreateTable(
                name: "Tur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    Sehir = table.Column<string>(nullable: true),
                    Tip = table.Column<string>(nullable: true),
                    Fiyat = table.Column<double>(nullable: true),
                    Ulasim = table.Column<string>(nullable: true),
                    Puan = table.Column<double>(nullable: true),
                    Fotograf = table.Column<string>(nullable: true)                  
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tur");
        }
    }
}
