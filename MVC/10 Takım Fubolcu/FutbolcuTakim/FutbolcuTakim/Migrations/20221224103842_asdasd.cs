using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutbolcuTakim.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lig",
                table: "Futbolcu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lig",
                table: "Futbolcu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
