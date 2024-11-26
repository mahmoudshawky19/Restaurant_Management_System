using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Table_Track.Migrations
{
    /// <inheritdoc />
    public partial class sass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_carts",
                table: "carts");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carts",
                table: "carts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_carts_MenuItemId",
                table: "carts",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_carts",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_MenuItemId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "id",
                table: "carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carts",
                table: "carts",
                columns: new[] { "MenuItemId", "ApplicationUserId" });
        }
    }
}
