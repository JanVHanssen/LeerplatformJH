using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Data.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GebruikerId",
                table: "Inschrijving",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebruiker_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
