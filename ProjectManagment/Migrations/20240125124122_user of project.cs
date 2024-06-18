using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagment.Migrations
{
    public partial class userofproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_AspNetUsers_UserId",
                table: "projects");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "projects",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_UserId",
                table: "projects",
                newName: "IX_projects_userId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "9a26dda7-3683-45f2-9fbb-b15be060e105");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "9828712d-8b8a-4428-9c74-4a5a95ada85b");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_AspNetUsers_userId",
                table: "projects",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_AspNetUsers_userId",
                table: "projects");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "projects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_userId",
                table: "projects",
                newName: "IX_projects_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "491bfc35-ced5-4532-90f2-da762bd496e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "b376e8d5-3191-41a7-8730-09c19fc40b79");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_AspNetUsers_UserId",
                table: "projects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
