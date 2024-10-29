using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Vid City", "Vivid", "5566778899", "55555", "Il", "99 Vivid st" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "L City", "Readers Club", "6669990000", "99999", "ny", "999 Main st" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { null, "Scifi", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { null, "History", null, null, null, null });
        }
    }
}
