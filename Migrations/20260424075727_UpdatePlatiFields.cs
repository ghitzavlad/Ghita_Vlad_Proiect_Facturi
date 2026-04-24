using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ghita_Vlad_Proiect_Facturi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlatiFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "Plati",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "Plati");
        }
    }
}
