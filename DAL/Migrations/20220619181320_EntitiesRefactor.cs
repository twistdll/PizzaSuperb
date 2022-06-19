using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class EntitiesRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderConfigurations_Doppings_DoppingId",
                table: "OrderConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderConfigurations_PizzaTypes_PizzaTypeId",
                table: "OrderConfigurations");

            migrationBuilder.DropTable(
                name: "Doppings");

            migrationBuilder.DropTable(
                name: "PizzaTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderConfigurations_DoppingId",
                table: "OrderConfigurations");

            migrationBuilder.DropColumn(
                name: "DoppingCount",
                table: "OrderConfigurations");

            migrationBuilder.DropColumn(
                name: "DoppingId",
                table: "OrderConfigurations");

            migrationBuilder.RenameColumn(
                name: "PizzaTypeId",
                table: "OrderConfigurations",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PizzaCount",
                table: "OrderConfigurations",
                newName: "ProductCount");

            migrationBuilder.RenameIndex(
                name: "IX_OrderConfigurations_PizzaTypeId",
                table: "OrderConfigurations",
                newName: "IX_OrderConfigurations_ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    IsForSale = table.Column<bool>(type: "bit", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderConfigurations_Products_ProductId",
                table: "OrderConfigurations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderConfigurations_Products_ProductId",
                table: "OrderConfigurations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderConfigurations",
                newName: "PizzaTypeId");

            migrationBuilder.RenameColumn(
                name: "ProductCount",
                table: "OrderConfigurations",
                newName: "PizzaCount");

            migrationBuilder.RenameIndex(
                name: "IX_OrderConfigurations_ProductId",
                table: "OrderConfigurations",
                newName: "IX_OrderConfigurations_PizzaTypeId");

            migrationBuilder.AddColumn<int>(
                name: "DoppingCount",
                table: "OrderConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoppingId",
                table: "OrderConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    IsForSale = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderConfigurations_DoppingId",
                table: "OrderConfigurations",
                column: "DoppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderConfigurations_Doppings_DoppingId",
                table: "OrderConfigurations",
                column: "DoppingId",
                principalTable: "Doppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderConfigurations_PizzaTypes_PizzaTypeId",
                table: "OrderConfigurations",
                column: "PizzaTypeId",
                principalTable: "PizzaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
