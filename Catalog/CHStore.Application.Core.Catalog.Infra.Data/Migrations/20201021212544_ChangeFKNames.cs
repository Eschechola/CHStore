using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    public partial class ChangeFKNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "fk_category_id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Product",
                newName: "fk_brand_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_fk_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                newName: "IX_Product_fk_brand_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 25, 44, 82, DateTimeKind.Local).AddTicks(8554),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 15, 41, 576, DateTimeKind.Local).AddTicks(2043));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fk_category_id",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "fk_brand_id",
                table: "Product",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_fk_category_id",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_fk_brand_id",
                table: "Product",
                newName: "IX_Product_BrandId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 15, 41, 576, DateTimeKind.Local).AddTicks(2043),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 25, 44, 82, DateTimeKind.Local).AddTicks(8554));
        }
    }
}
