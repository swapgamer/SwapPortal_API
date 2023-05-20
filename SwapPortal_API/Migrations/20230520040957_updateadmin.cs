using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapPortal_API.Migrations
{
    public partial class updateadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRolesName" },
                values: new object[] { 3, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 3);
        }
    }
}
