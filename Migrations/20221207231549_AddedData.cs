using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LamartTest.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackgroundColor",
                value: "Grey");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PointId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BackgroundColor", "PointId", "Text" },
                values: new object[,]
                {
                    { 4, "Aqua", 2, "Comment 4" },
                    { 5, "Blue", 2, "Comment 5" },
                    { 6, "Yellow", 2, "Comment 6 looooooooooooooooooong" },
                    { 7, "Grey", 2, "Comment 7" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Color", "Radius", "XPos", "YPos" },
                values: new object[] { 3, "Blue", 20, 1300, 500 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BackgroundColor", "PointId", "Text" },
                values: new object[,]
                {
                    { 8, "null", 3, "Comment 8" },
                    { 9, "brown", 3, "Comment 9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackgroundColor",
                value: "Yellow");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PointId",
                value: 2);
        }
    }
}
