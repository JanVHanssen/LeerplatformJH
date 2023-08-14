using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Data.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_StudentInschrijvingen_StudentInschrijvingenId",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Les_StudentLessen_StudentLessenId",
                table: "Les");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInschrijvingen",
                table: "StudentInschrijvingen");

            migrationBuilder.DropIndex(
                name: "IX_Les_StudentLessenId",
                table: "Les");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_StudentInschrijvingenId",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "StudentNaam",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "StudentNaam",
                table: "StudentInschrijvingen");

            migrationBuilder.DropColumn(
                name: "StudentLessenId",
                table: "Les");

            migrationBuilder.DropColumn(
                name: "StudentInschrijvingenId",
                table: "Inschrijving");

            migrationBuilder.RenameColumn(
                name: "StudentLessenId",
                table: "StudentLessen",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentInschrijvingenId",
                table: "StudentInschrijvingen",
                newName: "Studiepunten");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "StudentLessen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Docent",
                table: "StudentLessen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Locatie",
                table: "StudentLessen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Omschrijving",
                table: "StudentLessen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TijdstipEinde",
                table: "StudentLessen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TijdstipStart",
                table: "StudentLessen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Vak",
                table: "StudentLessen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Studiepunten",
                table: "StudentInschrijvingen",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentInschrijvingen",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Goedkeuring",
                table: "StudentInschrijvingen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Vak",
                table: "StudentInschrijvingen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "VakInschrijvingId",
                table: "Inschrijving",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInschrijvingen",
                table: "StudentInschrijvingen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving",
                column: "VakInschrijvingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_VakId",
                table: "Inschrijving",
                column: "VakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInschrijvingen",
                table: "StudentInschrijvingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_VakId",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "Docent",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "Locatie",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "Omschrijving",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "TijdstipEinde",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "TijdstipStart",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "Vak",
                table: "StudentLessen");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentInschrijvingen");

            migrationBuilder.DropColumn(
                name: "Goedkeuring",
                table: "StudentInschrijvingen");

            migrationBuilder.DropColumn(
                name: "Vak",
                table: "StudentInschrijvingen");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentLessen",
                newName: "StudentLessenId");

            migrationBuilder.RenameColumn(
                name: "Studiepunten",
                table: "StudentInschrijvingen",
                newName: "StudentInschrijvingenId");

            migrationBuilder.AddColumn<string>(
                name: "StudentNaam",
                table: "StudentLessen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentInschrijvingenId",
                table: "StudentInschrijvingen",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "StudentNaam",
                table: "StudentInschrijvingen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentLessenId",
                table: "Les",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VakInschrijvingId",
                table: "Inschrijving",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudentInschrijvingenId",
                table: "Inschrijving",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInschrijvingen",
                table: "StudentInschrijvingen",
                column: "StudentInschrijvingenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving",
                columns: new[] { "VakId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Les_StudentLessenId",
                table: "Les",
                column: "StudentLessenId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_StudentInschrijvingenId",
                table: "Inschrijving",
                column: "StudentInschrijvingenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_StudentInschrijvingen_StudentInschrijvingenId",
                table: "Inschrijving",
                column: "StudentInschrijvingenId",
                principalTable: "StudentInschrijvingen",
                principalColumn: "StudentInschrijvingenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Les_StudentLessen_StudentLessenId",
                table: "Les",
                column: "StudentLessenId",
                principalTable: "StudentLessen",
                principalColumn: "StudentLessenId");
        }
    }
}
