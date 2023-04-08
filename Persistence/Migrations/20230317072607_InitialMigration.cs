using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdeaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ideas_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1e6075a3-a411-42d0-9711-f901714c86df"), "Education" },
                    { new Guid("2ed64fe5-cd54-4cd0-9898-8d3d759c2f00"), "Business" },
                    { new Guid("3088c1ee-60be-45e8-bbb1-6d9f5b68365b"), "Utility" },
                    { new Guid("d3ee4713-ea7b-4097-9c99-3c6f585185d8"), "Medicine" },
                    { new Guid("ed2fa5f2-0692-41f2-ba8e-4b41847b2c44"), "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Ideas",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Name" },
                values: new object[] { new Guid("b77ac3c5-63df-4787-bd8d-664521b3c83a"), new Guid("3088c1ee-60be-45e8-bbb1-6d9f5b68365b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An app which makes recommendations on which metro stations to improve based on feedback and recommendations on where one could be opened to meet the demand.", "Metro application featuring AI" });

            migrationBuilder.InsertData(
                table: "Ideas",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Name" },
                values: new object[] { new Guid("c7770086-60ad-4e60-b215-b681da299eeb"), new Guid("3088c1ee-60be-45e8-bbb1-6d9f5b68365b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "With recent AI advancements, application development can benefit greatly. This use case is one of the many viable ones.", "Create an weather app powered by AI!" });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_CategoryId",
                table: "Ideas",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
