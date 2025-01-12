using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GST_API_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTableGSTR1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gstr1",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GSTINNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FinancialPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaveGstr1Status = table.Column<int>(type: "int", nullable: false),
                    Gstr1SaveRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaveGstr1Reponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewProceedToFileGstr1Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewProceedToFileGstr1Reponse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gstr1", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gstr1");

        }
    }
}
