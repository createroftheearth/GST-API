using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GST_API_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddGSTR3Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gstr3B");

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

            migrationBuilder.CreateTable(
                name: "Gstr3",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GSTINNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FinancialPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaveGstr3Status = table.Column<int>(type: "int", nullable: true),
                    GetGSTR3Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetGSTR3Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gstr3SaveRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaveGstr3Reponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gstr3", x => x.Id);
                });

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gstr3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7976c0c0-8ce9-4616-9555-0efd07ddea2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "989b355d-9861-416f-8757-88e11ab7c9db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c545afc9-3776-4f99-8101-8d7aaf899c8b");

            migrationBuilder.CreateTable(
                name: "Gstr3B",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GSTINNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gstr3SaveRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewProceedToFileGstr3Reponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewProceedToFileGstr3Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaveGstr3Reponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaveGstr3Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gstr3B", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ad82635-102b-4aa4-9ef8-99278da4b4c9", "1", "APIUser", "APIUser" },
                    { "acc73ff8-7247-4c22-a01d-c9295195e35b", "1", "PublicUser", "PublicUser" },
                    { "ea51cc2a-0012-43df-872d-9758428cd888", "1", "ASPUser", "ASPUser" }
                });
        }
    }
}
