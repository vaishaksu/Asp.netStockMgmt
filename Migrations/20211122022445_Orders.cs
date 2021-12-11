using Microsoft.EntityFrameworkCore.Migrations;

namespace StockManagement.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_item_id1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_item_id1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "item_id1",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "item_id",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "item_id1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_item_id1",
                table: "Orders",
                column: "item_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_item_id1",
                table: "Orders",
                column: "item_id1",
                principalTable: "Items",
                principalColumn: "item_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
