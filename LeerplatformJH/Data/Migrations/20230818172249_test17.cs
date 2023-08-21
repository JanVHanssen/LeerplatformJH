using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Data.Migrations
{
    public partial class test17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Gebruiker_GebruikerId",
                table: "Inschrijving");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_GebruikerId",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "GebruikerId",
                table: "Inschrijving");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GebruikerId",
                table: "Inschrijving",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.GebruikerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_GebruikerId",
                table: "Inschrijving",
                column: "GebruikerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Gebruiker_GebruikerId",
                table: "Inschrijving",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "GebruikerId");
        }
    }
}
