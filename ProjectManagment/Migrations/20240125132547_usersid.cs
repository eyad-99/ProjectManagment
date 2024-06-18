using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagment.Migrations
{
    public partial class usersid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_AspNetUsers_userId",
                table: "projects");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "projects",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_projects_userId",
                table: "projects",
                newName: "IX_projects_userid");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "50c7b772-3872-4965-9fd1-317ab1e472f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "2651002d-dc71-408a-bbe8-e4a82116a514");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_AspNetUsers_userid",
                table: "projects",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_AspNetUsers_userid",
                table: "projects");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "projects",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_userid",
                table: "projects",
                newName: "IX_projects_userId");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
