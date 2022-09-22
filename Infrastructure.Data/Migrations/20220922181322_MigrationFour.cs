using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class MigrationFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Customers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBankInfos_CustomerId",
                table: "CustomerBankInfos",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankInfos_Customers_CustomerId",
                table: "CustomerBankInfos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankInfos_Customers_CustomerId",
                table: "CustomerBankInfos");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBankInfos_CustomerId",
                table: "CustomerBankInfos");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Customers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerBankInfos_Id",
                table: "Customers",
                column: "Id",
                principalTable: "CustomerBankInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
