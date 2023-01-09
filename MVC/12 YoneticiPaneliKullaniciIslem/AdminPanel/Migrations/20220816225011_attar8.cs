using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPanel.Migrations
{
    public partial class attar8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaketDurumu",
                table: "SiparisDetay",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaketDurumu",
                table: "SepetUrunler",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaketDurumu",
                table: "SiparisDetay");

            migrationBuilder.DropColumn(
                name: "PaketDurumu",
                table: "SepetUrunler");
        }
    }
}
