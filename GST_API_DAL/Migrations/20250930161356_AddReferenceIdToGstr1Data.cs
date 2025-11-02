using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GST_API_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReferenceIdToGstr1Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "286cb057-92bd-4203-b584-d05c99388246");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c8ff95-6511-4bb4-9839-f96f66c05854");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebaa7d76-0042-4e8d-893e-11a0945a9ced");

            migrationBuilder.DropColumn(
                name: "GetSummaryResponse",
                table: "Gstr3B");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceId",
                table: "Gstr1",
                type: "nvarchar(max)",
                nullable: true);

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ad82635-102b-4aa4-9ef8-99278da4b4c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc73ff8-7247-4c22-a01d-c9295195e35b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea51cc2a-0012-43df-872d-9758428cd888");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Gstr1");

            migrationBuilder.AddColumn<string>(
                name: "GetSummaryResponse",
                table: "Gstr3B",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "286cb057-92bd-4203-b584-d05c99388246", "1", "PublicUser", "PublicUser" },
                    { "d4c8ff95-6511-4bb4-9839-f96f66c05854", "1", "ASPUser", "ASPUser" },
                    { "ebaa7d76-0042-4e8d-893e-11a0945a9ced", "1", "APIUser", "APIUser" }
                });
        }
    }
}
