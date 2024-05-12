using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infastucture.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_popularTopics_topic_TopicModelId",
                table: "popularTopics");

            migrationBuilder.DropIndex(
                name: "IX_popularTopics_TopicModelId",
                table: "popularTopics");

            migrationBuilder.DropColumn(
                name: "TopicModelId",
                table: "popularTopics");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "popularTopics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_popularTopics_TopicId",
                table: "popularTopics",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_popularTopics_topic_TopicId",
                table: "popularTopics",
                column: "TopicId",
                principalTable: "topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_popularTopics_topic_TopicId",
                table: "popularTopics");

            migrationBuilder.DropIndex(
                name: "IX_popularTopics_TopicId",
                table: "popularTopics");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "popularTopics");

            migrationBuilder.AddColumn<int>(
                name: "TopicModelId",
                table: "popularTopics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_popularTopics_TopicModelId",
                table: "popularTopics",
                column: "TopicModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_popularTopics_topic_TopicModelId",
                table: "popularTopics",
                column: "TopicModelId",
                principalTable: "topic",
                principalColumn: "Id");
        }
    }
}
