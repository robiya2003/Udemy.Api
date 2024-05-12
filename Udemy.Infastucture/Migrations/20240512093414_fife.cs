using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infastucture.Migrations
{
    /// <inheritdoc />
    public partial class fife : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_popularTopics_PopularTopicModelId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_PopularTopicModelId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "PopularTopicModelId",
                table: "courses");

            migrationBuilder.AddColumn<int>(
                name: "popularTopicId",
                table: "courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_popularTopicId",
                table: "courses",
                column: "popularTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_popularTopics_popularTopicId",
                table: "courses",
                column: "popularTopicId",
                principalTable: "popularTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_popularTopics_popularTopicId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_popularTopicId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "popularTopicId",
                table: "courses");

            migrationBuilder.AddColumn<int>(
                name: "PopularTopicModelId",
                table: "courses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_PopularTopicModelId",
                table: "courses",
                column: "PopularTopicModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_popularTopics_PopularTopicModelId",
                table: "courses",
                column: "PopularTopicModelId",
                principalTable: "popularTopics",
                principalColumn: "Id");
        }
    }
}
