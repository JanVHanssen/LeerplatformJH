using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Migrations
{
    public partial class initializecreate : Migration
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "StudentInschrijvingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInschrijvingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInschrijvingen_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLessen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLessen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLessen_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijving",
                columns: table => new
                {
                    VakInschrijvingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: false),
                    Goedkeuring = table.Column<int>(type: "int", nullable: true),
                    StudentInschrijvingenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijving", x => x.VakInschrijvingId);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijving_StudentInschrijvingen_StudentInschrijvingenId",
                        column: x => x.StudentInschrijvingenId,
                        principalTable: "StudentInschrijvingen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inschrijving_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "VakId",
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
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DocentId = table.Column<int>(type: "int", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: false),
                    StudentLessenId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Les_StudentLessen_StudentLessenId",
                        column: x => x.StudentLessenId,
                        principalTable: "StudentLessen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Les_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "VakId");
                });

            migrationBuilder.CreateTable(
                name: "LesStudent",
                columns: table => new
                {
                    LesId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesStudent", x => new { x.LesId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_LesStudent_Les_LesId",
                        column: x => x.LesId,
                        principalTable: "Les",
                        principalColumn: "LesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LesStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "VakInschrijvingId", "Goedkeuring", "StudentId", "StudentInschrijvingenId", "Titel", "VakId" },
                values: new object[,]
                {
                    { 1, 0, 1, null, "Jan Hanssen Nederlands 2023", 3 },
                    { 2, 0, 1, null, "Jan Hanssen Wiskunde 2023", 2 },
                    { 3, 0, 1, null, "Jan Hanssen Engels 2023", 1 },
                    { 4, 0, 2, null, "Wim Billen Engels 2023", 1 },
                    { 5, 1, 2, null, "Wim Billen Frans 2023", 5 },
                    { 6, 2, 2, null, "Wim Billen Nederlands 2023", 3 },
                    { 7, 0, 3, null, "Anne Broekmans Economie 2023", 4 },
                    { 8, 1, 3, null, "Anne Broekmans Wiskunde 2023", 2 },
                    { 9, 2, 3, null, "Anne Broekmans Engels 2023", 1 },
                    { 10, 0, 4, null, "Sara Putzeys Engels 2023", 1 },
                    { 11, 1, 4, null, "Sara Putzeys Frans 2023", 5 },
                    { 12, 0, 4, null, "Sara Putzeys Nederlands 2023", 3 },
                    { 13, 0, 5, null, "Steven Grosemans Wiskunde 2023", 2 },
                    { 14, 0, 5, null, "Steven Grosemans Economie 2023", 4 },
                    { 15, 0, 5, null, "Steven Grosemans Frans 2023", 5 },
                    { 16, 0, 6, null, "Elke Vandeplas Engels 2023", 1 },
                    { 17, 0, 6, null, "Elke Vandeplas Nederlands 2023", 3 },
                    { 18, 0, 6, null, "Elke Vandeplas Frans 2023", 5 },
                    { 19, 0, 7, null, "Laura Janssen Wiskunde 2023", 2 },
                    { 20, 0, 7, null, "Laura Janssen Economie 2023", 4 },
                    { 21, 0, 7, null, "Laura Janssen Nederlands 2023", 3 },
                    { 22, 0, 8, null, "Willem Omloop Engels 2023", 1 },
                    { 23, 0, 8, null, "Willem Omloop Frans 2023", 5 },
                    { 24, 0, 8, null, "Willem Omloop Wiskunde 2023", 2 }
                });

            migrationBuilder.InsertData(
                table: "Les",
                columns: new[] { "LesId", "DocentId", "LokaalId", "Omschrijving", "StudentId", "StudentLessenId", "TijdstipEinde", "TijdstipStart", "Titel", "VakId" },
                values: new object[,]
                {
                    { 1, 2, 1, "Introductie tot de lineaire algebra", 0, null, new DateTime(2023, 9, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), "Wiskunde1A", 2 },
                    { 2, 4, 2, "Marxisme", 0, null, new DateTime(2023, 9, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), "Economie1B", 4 },
                    { 3, 3, 3, "Het lijdend voorwerp", 0, null, new DateTime(2023, 9, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Nederlands1A", 3 },
                    { 4, 3, 5, "Het meewerkend voorwerp", 0, null, new DateTime(2023, 9, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Nederlands1B", 3 },
                    { 5, 1, 4, "Inleiding", 0, null, new DateTime(2023, 9, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Engels1A", 1 },
                    { 6, 1, 1, "Pronunciation", 0, null, new DateTime(2023, 9, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), "Engels1B", 1 },
                    { 7, 4, 1, "Wat is economie?", 0, null, new DateTime(2029, 9, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Economie1A", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_StudentId",
                table: "Inschrijving",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_StudentInschrijvingenId",
                table: "Inschrijving",
                column: "StudentInschrijvingenId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_VakId",
                table: "Inschrijving",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_DocentId",
                table: "Les",
                column: "DocentId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_LokaalId",
                table: "Les",
                column: "LokaalId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_StudentLessenId",
                table: "Les",
                column: "StudentLessenId");

            migrationBuilder.CreateIndex(
                name: "IX_Les_VakId",
                table: "Les",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_LesStudent_StudentId",
                table: "LesStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInschrijvingen_StudentId",
                table: "StudentInschrijvingen",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessen_StudentId",
                table: "StudentLessen",
                column: "StudentId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Inschrijving");

            migrationBuilder.DropTable(
                name: "LesStudent");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StudentInschrijvingen");

            migrationBuilder.DropTable(
                name: "Les");

            migrationBuilder.DropTable(
                name: "Lokaal");

            migrationBuilder.DropTable(
                name: "StudentLessen");

            migrationBuilder.DropTable(
                name: "Vak");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Docent");
        }
    }
}
