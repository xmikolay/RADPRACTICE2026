using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S00254903_ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class MakeLecturerIDNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturerID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerID",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturerID",
                table: "Courses",
                column: "LecturerID",
                principalTable: "Lecturers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturerID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturerID",
                table: "Courses",
                column: "LecturerID",
                principalTable: "Lecturers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
