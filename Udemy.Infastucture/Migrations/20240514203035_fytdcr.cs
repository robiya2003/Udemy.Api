using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infastucture.Migrations
{
    /// <inheritdoc />
    public partial class fytdcr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "news",
                newName: "NewsPhotoPath");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "lessons",
                newName: "LessonPhotoPath");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "courses",
                newName: "CoursePhotoPath");

            migrationBuilder.AddColumn<string>(
                name: "AutherPhotoPath",
                table: "authers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutherPhotoPath",
                table: "authers");

            migrationBuilder.RenameColumn(
                name: "NewsPhotoPath",
                table: "news",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "LessonPhotoPath",
                table: "lessons",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "CoursePhotoPath",
                table: "courses",
                newName: "PhotoPath");
        }
    }
}
