using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infastucture.Migrations
{
    /// <inheritdoc />
    public partial class fie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PopularTopicPhotoPath",
                table: "popularTopics",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PopularTopicPhotoPath",
                table: "popularTopics");
        }
    }
}
