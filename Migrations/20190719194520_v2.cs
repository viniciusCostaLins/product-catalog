using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "money",
                table: "Product",
                newName: "Price");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "money",
                table: "Product",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
