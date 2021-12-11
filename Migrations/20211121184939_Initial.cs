using Microsoft.EntityFrameworkCore.Migrations;

namespace StockManagement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seller_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    in_stock = table.Column<bool>(type: "bit", nullable: false),
                    item_image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.item_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_admin = table.Column<bool>(type: "bit", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    user_id1 = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    item_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_Customers_Items_item_id1",
                        column: x => x.item_id1,
                        principalTable: "Items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    item_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Items_item_id1",
                        column: x => x.item_id1,
                        principalTable: "Items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "item_id", "in_stock", "item_image", "item_name", "price", "quantity", "seller_name" },
                values: new object[,]
                {
                    { 101, true, "Image7.jpg", "Mobile", 5000.0, 40, "Sadguru" },
                    { 102, true, "Image1.jpg", "bag", 5000.0, 40, "Sadguru" },
                    { 103, true, "Image5.jpg", "Study Lamp", 5000.0, 40, "Sadguru" },
                    { 104, true, "Image13.jpg", "Night Lamp", 5000.0, 40, "Sadguru" },
                    { 105, true, "Image7.jpg", "Mobile", 5000.0, 40, "Sadguru" },
                    { 106, true, "Image12.jpg", "Watch", 5000.0, 40, "Sadguru" },
                    { 107, true, "Image10.jpg", "Tomato", 5000.0, 40, "Sadguru" },
                    { 108, true, "Image2.jpg", "Clothes", 5000.0, 40, "Sadguru" },
                    { 109, true, "Image9.jpg", "Table", 5000.0, 40, "Sadguru" },
                    { 100, true, "Image4.jpg", "Guitar", 5000.0, 40, "Sadguru" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "is_admin", "password", "username" },
                values: new object[,]
                {
                    { 1000, true, "password", "root" },
                    { 1001, false, "password1", "abc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_item_id1",
                table: "Customers",
                column: "item_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_user_id1",
                table: "Customers",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                table: "Orders",
                column: "customer_id",
                unique: true,
                filter: "[customer_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_item_id1",
                table: "Orders",
                column: "item_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
