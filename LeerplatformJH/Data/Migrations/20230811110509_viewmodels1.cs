using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeerplatformJH.Data.Migrations
{
    public partial class viewmodels1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentLessenId",
                table: "Les",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentLessen",
                columns: table => new
                {
                    StudentLessenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNaam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLessen", x => x.StudentLessenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Les_StudentLessenId",
                table: "Les",
                column: "StudentLessenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Les_StudentLessen_StudentLessenId",
                table: "Les",
                column: "StudentLessenId",
                principalTable: "StudentLessen",
                principalColumn: "StudentLessenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Les_StudentLessen_StudentLessenId",
                table: "Les");

            migrationBuilder.DropTable(
                name: "StudentLessen");

            migrationBuilder.DropIndex(
                name: "IX_Les_StudentLessenId",
                table: "Les");

            migrationBuilder.DropColumn(
                name: "StudentLessenId",
                table: "Les");
        }
    }
}
