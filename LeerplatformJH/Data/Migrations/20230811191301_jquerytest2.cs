using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Data.Migrations
{
    public partial class jquerytest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "AdministratorId", "Achternaam", "Email", "Indiensttreding", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Janssens", "Janssens.Fons@Ucll.be", new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fons" },
                    { 2, "Vandenbroek", "Vandenbroek.Tom@Ucll.be", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom" },
                    { 3, "Willems", "Willems.Artuur@Ucll.be", new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artuur" }
                });

            migrationBuilder.InsertData(
                table: "Docent",
                columns: new[] { "DocentId", "Achternaam", "Email", "Indiensttreding", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Vanneste", "Kim.Vanneste@Ucll.be", new DateTime(2015, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kim" },
                    { 2, "Achten", "Jurgen.Achten@Ucll.be", new DateTime(2012, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurgen" },
                    { 3, "Smets", "Roger.Smets@Ucll.be", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roger" },
                    { 4, "Knopper", "Lotte.Knopper@Ucll.be", new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lotte" },
                    { 5, "Colson", "Maarten.Colson@Ucll.be", new DateTime(2012, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maarten" }
                });

            migrationBuilder.InsertData(
                table: "Lokaal",
                columns: new[] { "LokaalId", "Capaciteit", "Middelen", "Omschrijving", "Titel" },
                values: new object[,]
                {
                    { 1, 40, "Whiteboard", "Stationstraat 2, 3001 Heverlee", "Heverlee kleine zaal" },
                    { 2, 60, "Projector, Micro, Whiteboard", "Stationstraat 2, 3001 Heverlee", "Heverlee grote zaal" },
                    { 3, 30, "Whiteboard", "Nieuwstraat 8, 3000 Leuven", "Leuven kleine zaal 1" },
                    { 4, 70, "Projector, Micro, Whiteboard", "Nieuwstraat 8, 3000 Leuven", "Leuven grote zaal" },
                    { 5, 35, "Whiteboard", "Nieuwstraat 8, 3000 Leuven", "Leuven kleine zaal 2" }
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

            migrationBuilder.InsertData(
                table: "Les",
                columns: new[] { "LesId", "DocentId", "LokaalId", "Omschrijving", "StudentLessenId", "TijdstipEinde", "TijdstipStart", "Titel", "VakId" },
                values: new object[,]
                {
                    { 1, null, 1, "Introductie tot de lineaire algebra", null, new DateTime(2023, 9, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), "Wiskunde1A", null },
                    { 2, null, 2, "Marxisme", null, new DateTime(2023, 9, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), "Economie1B", null },
                    { 3, null, 3, "Het lijdend voorwerp", null, new DateTime(2023, 9, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Nederlands1A", null },
                    { 4, null, 5, "Het meewerkend voorwerp", null, new DateTime(2023, 9, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Nederlands1B", null },
                    { 5, null, 4, "Inleiding", null, new DateTime(2023, 9, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Engels1A", null },
                    { 6, null, 1, "Pronunciation", null, new DateTime(2023, 9, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), "Engels1B", null },
                    { 7, null, 1, "Wat is economie?", null, new DateTime(2029, 9, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Economie1A", null }
                });

            migrationBuilder.InsertData(
                table: "Vak",
                columns: new[] { "VakId", "DocentId", "Studiepunten", "Titel" },
                values: new object[,]
                {
                    { 1, 1, 4, "Engels" },
                    { 2, 2, 4, "Wiskunde" },
                    { 3, 3, 3, "Nederlands" },
                    { 4, 4, 3, "Economie" },
                    { 5, 5, 4, "Frans" }
                });

            migrationBuilder.InsertData(
                table: "Inschrijving",
                columns: new[] { "StudentId", "VakId", "DocentId", "Goedkeuring", "LesId", "StudentInschrijvingenId", "Titel", "VakInschrijvingId" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, "Jan Hanssen Engels 2023", 3 },
                    { 2, 1, null, null, null, null, "Wim Billen Engels 2023", 4 },
                    { 3, 1, null, null, null, null, "Anne Broekmans Engels 2023", 9 },
                    { 4, 1, null, null, null, null, "Sara Putzeys Engels 2023", 10 },
                    { 6, 1, null, null, null, null, "Elke Vandeplas Engels 2023", 16 },
                    { 8, 1, null, null, null, null, "Willem Omloop Engels 2023", 22 },
                    { 1, 2, null, null, null, null, "Jan Hanssen Wiskunde 2023", 2 },
                    { 3, 2, null, null, null, null, "Anne Broekmans Wiskunde 2023", 8 },
                    { 5, 2, null, null, null, null, "Steven Grosemans Wiskunde 2023", 13 },
                    { 7, 2, null, null, null, null, "Laura Janssen Wiskunde 2023", 19 },
                    { 8, 2, null, null, null, null, "Willem Omloop Wiskunde 2023", 24 },
                    { 1, 3, null, null, null, null, "Jan Hanssen Nederlands 2023", 1 },
                    { 2, 3, null, null, null, null, "Wim Billen Nederlands 2023", 6 },
                    { 4, 3, null, null, null, null, "Sara Putzeys Nederlands 2023", 12 },
                    { 6, 3, null, null, null, null, "Elke Vandeplas Nederlands 2023", 17 },
                    { 7, 3, null, null, null, null, "Laura Janssen Nederlands 2023", 21 },
                    { 3, 4, null, null, null, null, "Anne Broekmans Economie 2023", 7 },
                    { 5, 4, null, null, null, null, "Steven Grosemans Economie 2023", 14 },
                    { 7, 4, null, null, null, null, "Laura Janssen Economie 2023", 20 },
                    { 2, 5, null, null, null, null, "Wim Billen Frans 2023", 5 },
                    { 4, 5, null, null, null, null, "Sara Putzeys Frans 2023", 11 },
                    { 5, 5, null, null, null, null, "Steven Grosemans Frans 2023", 15 },
                    { 6, 5, null, null, null, null, "Elke Vandeplas Frans 2023", 18 },
                    { 8, 5, null, null, null, null, "Willem Omloop Frans 2023", 23 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrator",
                keyColumn: "AdministratorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Administrator",
                keyColumn: "AdministratorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Administrator",
                keyColumn: "AdministratorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "Inschrijving",
                keyColumns: new[] { "StudentId", "VakId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Les",
                keyColumn: "LesId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lokaal",
                keyColumn: "LokaalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lokaal",
                keyColumn: "LokaalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lokaal",
                keyColumn: "LokaalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lokaal",
                keyColumn: "LokaalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lokaal",
                keyColumn: "LokaalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "VakId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "VakId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "VakId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "VakId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vak",
                keyColumn: "VakId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Docent",
                keyColumn: "DocentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Docent",
                keyColumn: "DocentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Docent",
                keyColumn: "DocentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Docent",
                keyColumn: "DocentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Docent",
                keyColumn: "DocentId",
                keyValue: 5);
        }
    }
}
