using Microsoft.EntityFrameworkCore.Migrations;

namespace ABPCommerce.Migrations
{
    public partial class ExtraUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgBase64",
                table: "AbpUsers",
                type: "nvarchar(max)",
                maxLength: 1048576,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "AbpUsers",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AbpUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AbpUsers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgBase64",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AbpUsers");
        }
    }
}
