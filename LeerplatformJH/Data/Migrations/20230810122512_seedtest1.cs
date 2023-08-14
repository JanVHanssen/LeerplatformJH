using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Data.Migrations
{
    public partial class seedtest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indiensttreding = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "Docent",
                columns: table => new
                {
                    DocentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indiensttreding = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docent", x => x.DocentId);
                });

            migrationBuilder.CreateTable(
                name: "Lokaal",
                columns: table => new
                {
                    LokaalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capaciteit = table.Column<int>(type: "int", nullable: false),
                    Middelen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokaal", x => x.LokaalId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inschrijvingsdatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Vak",
                columns: table => new
                {
                    VakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Studiepunten = table.Column<int>(type: "int", nullable: false),
                    DocentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vak", x => x.VakId);
                    table.ForeignKey(
                        name: "FK_Vak_Docent_DocentId",
                        column: x => x.DocentId,
                        principalTable: "Docent",
                        principalColumn: "DocentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Les",
                columns: table => new
                {
                    LesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TijdstipStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TijdstipEinde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LokaalId = table.Column<int>(type: "int", nullable: false),
                    DocentId = table.Column<int>(type: "int", nullable: true),
                    VakId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Les", x => x.LesId);
                    table.ForeignKey(
                        name: "FK_Les_Docent_DocentId",
                        column: x => x.DocentId,
                        principalTable: "Docent",
                        principalColumn: "DocentId");
                    table.ForeignKey(
                        name: "FK_Les_Lokaal_LokaalId",
                        column: x => x.LokaalId,
                        principalTable: "Lokaal",
                        principalColumn: "LokaalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Les_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "VakId");
                });

            migrationBuilder.CreateTable(
                name: "Inschrijving",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: false),
                    VakInschrijvingId = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goedkeuring = table.Column<int>(type: "int", nullable: true),
                    DocentId = table.Column<int>(type: "int", nullable: true),
                    LesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijving", x => new { x.VakId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_Inschrijving_Docent_DocentId",
                        column: x => x.DocentId,
                        principalTable: "Docent",
                        principalColumn: "DocentId");
                    table.ForeignKey(
                        name: "FK_Inschrijving_Les_LesId",
                        column: x => x.LesId,
                        principalTable: "Les",
                        principalColumn: "LesId");
                    table.ForeignKey(
                        name: "FK_Inschrijving_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "VakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LesStudent",
                columns: table => new
                {
                    LessenLesId = table.Column<int>(type: "int", nullable: false),
                    StudentenStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesStudent", x => new { x.LessenLesId, x.StudentenStudentId });
                    table.ForeignKey(
                        name: "FK_LesStudent_Les_LessenLesId",
                        column: x => x.LessenLesId,
                        principalTable: "Les",
                        principalColumn: "LesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LesStudent_Student_StudentenStudentId",
                        column: x => x.StudentenStudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Achternaam", "Email", "Inschrijvingsdatum", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Hanssen", "Jan.Hanssen@hotmail.com", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan" },
                    { 2, "Billen", "Wim.Billen@hotmail.com", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wim" },
                    { 3, "Broekmans", "Anne.Broekmans@hotmail.com", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anne" },
                    { 4, "Putzeys", "Sara.Putzeys@hotmail.com", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara" },
                    { 5, "Grosemans", "Steven.Grosemans@hotmail.com", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven" },
                    { 6, "Vandeplas", "Elke.Vandeplas@hotmail.com", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elke" },
                    { 7, "Janssen", "Laura.Janssen@hotmail.com", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura" },
                    { 8, "Omloop", "Willem.Omloop@hotmail.com", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willem" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_DocentId",
                table: "Inschrijving",
                column: "DocentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_LesId",
                table: "Inschrijving",
                column: "LesId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_StudentId",
                table: "Inschrijving",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_DocentId",
                table: "Les",
                column: "DocentId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_LokaalId",
                table: "Les",
                column: "LokaalId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_VakId",
                table: "Les",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_LesStudent_StudentenStudentId",
                table: "LesStudent",
                column: "StudentenStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vak_DocentId",
                table: "Vak",
                column: "DocentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Inschrijving");

            migrationBuilder.DropTable(
                name: "LesStudent");

            migrationBuilder.DropTable(
                name: "Les");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Lokaal");

            migrationBuilder.DropTable(
                name: "Vak");

            migrationBuilder.DropTable(
                name: "Docent");
        }
    }
}
