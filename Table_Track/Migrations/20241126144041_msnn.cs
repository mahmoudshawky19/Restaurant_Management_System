using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Table_Track.Migrations
{
    /// <inheritdoc />
    public partial class msnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "menuItems",
                newName: "PriceBefore");

            migrationBuilder.AddColumn<double>(
                name: "PriceAfter",
                table: "menuItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceAfter",
                table: "menuItems");

            migrationBuilder.RenameColumn(
                name: "PriceBefore",
                table: "menuItems",
                newName: "Price");

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pricebefore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_offers_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_offers_CategoryId",
                table: "offers",
                column: "CategoryId");
        }
    }
}
