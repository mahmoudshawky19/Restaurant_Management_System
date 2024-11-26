using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Table_Track.Migrations
{
    /// <inheritdoc />
    public partial class oiu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_offers_CategoryId",
                table: "offers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_offers_categories_CategoryId",
                table: "offers",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_offers_categories_CategoryId",
                table: "offers");

            migrationBuilder.DropIndex(
                name: "IX_offers_CategoryId",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "offers");
        }
    }
}
