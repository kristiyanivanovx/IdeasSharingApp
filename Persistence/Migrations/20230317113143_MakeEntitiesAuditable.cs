using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class MakeEntitiesAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Ideas",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Likes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Ideas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("1e6075a3-a411-42d0-9711-f901714c86df"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2ed64fe5-cd54-4cd0-9898-8d3d759c2f00"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("3088c1ee-60be-45e8-bbb1-6d9f5b68365b"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("d3ee4713-ea7b-4097-9c99-3c6f585185d8"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("ed2fa5f2-0692-41f2-ba8e-4b41847b2c44"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "Ideas",
                keyColumn: "IdeaId",
                keyValue: new Guid("b77ac3c5-63df-4787-bd8d-664521b3c83a"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Ideas",
                keyColumn: "IdeaId",
                keyValue: new Guid("c7770086-60ad-4e60-b215-b681da299eeb"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 17, 11, 31, 42, 894, DateTimeKind.Utc).AddTicks(8958));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Ideas",
                newName: "CreatedOn");

            migrationBuilder.UpdateData(
                table: "Ideas",
                keyColumn: "IdeaId",
                keyValue: new Guid("b77ac3c5-63df-4787-bd8d-664521b3c83a"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ideas",
                keyColumn: "IdeaId",
                keyValue: new Guid("c7770086-60ad-4e60-b215-b681da299eeb"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
