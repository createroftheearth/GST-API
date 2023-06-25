using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GST_API_DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9ee718f-fe91-4fd9-81f7-98fe8291317e", "1", "APIUser", "APIUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9ee718f-fe91-4fd9-81f7-98fe8291317e");
        }
    }
}
