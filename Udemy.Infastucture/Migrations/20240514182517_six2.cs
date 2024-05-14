using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infastucture.Migrations
{
    /// <inheritdoc />
    public partial class six2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TopicPhotoPath",
                table: "topic",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopicPhotoPath",
                table: "topic");
        }
    }
}
