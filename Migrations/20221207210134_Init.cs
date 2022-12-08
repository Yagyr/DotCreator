using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LamartTest.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XPos = table.Column<int>(type: "int", nullable: false),
                    YPos = table.Column<int>(type: "int", nullable: false),
                    Radius = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Color", "Radius", "XPos", "YPos" },
                values: new object[,]
                {
                    { 1, "Yellow", 50, 500, 80 },
                    { 2, "Green", 20, 800, 150 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BackgroundColor", "PointId", "Text" },
                values: new object[,]
                {
                    { 1, "null", 1, "Comment 1" },
                    { 2, "Yellow", 1, "Comment 2" },
                    { 3, "null", 2, "Comment 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PointId",
                table: "Comments",
                column: "PointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
