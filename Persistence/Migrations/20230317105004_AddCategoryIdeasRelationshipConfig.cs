using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddCategoryIdeasRelationshipConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Likes",
                newName: "LikeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ideas",
                newName: "IdeaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LikeId",
                table: "Likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdeaId",
                table: "Ideas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");
        }
    }
}
