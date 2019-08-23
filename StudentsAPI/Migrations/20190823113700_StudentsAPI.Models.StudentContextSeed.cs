using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsAPI.Migrations
{
    public partial class StudentsAPIModelsStudentContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "City", "Country", "FirstName", "LastName", "University" },
                values: new object[] { 1L, "Yerevan", "Armenia", "Margarit", "Safaryan", "NPUA" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "City", "Country", "FirstName", "LastName", "University" },
                values: new object[] { 2L, "Cambridge", "USA", "Will", "Smith", "MIT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2L);
        }
    }
}
