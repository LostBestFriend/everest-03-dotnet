using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class AlterTablePortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Portfolios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CustomerId",
                table: "Portfolios",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Customers_CustomerId",
                table: "Portfolios",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Customers_CustomerId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_CustomerId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Portfolios");
        }
    }
}
