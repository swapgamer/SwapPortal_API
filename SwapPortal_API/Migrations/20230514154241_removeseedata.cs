using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapPortal_API.Migrations
{
    public partial class removeseedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRolesName" },
                values: new object[] { 1, "Recruiter" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRolesName" },
                values: new object[] { 2, "Applicant" });
        }
    }
}
