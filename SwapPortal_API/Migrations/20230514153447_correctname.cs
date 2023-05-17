using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapPortal_API.Migrations
{
    public partial class correctname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRolesId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRolesId",
                table: "Users",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRolesId",
                table: "Users",
                newName: "IX_Users_UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "Users",
                newName: "UserRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                newName: "IX_Users_UserRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRolesId",
                table: "Users",
                column: "UserRolesId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
