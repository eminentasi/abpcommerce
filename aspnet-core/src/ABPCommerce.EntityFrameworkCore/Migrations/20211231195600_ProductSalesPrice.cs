using Microsoft.EntityFrameworkCore.Migrations;

namespace ABPCommerce.Migrations
{
    public partial class ProductSalesPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalesPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "Products");
        }
    }
}
