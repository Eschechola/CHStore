using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    public partial class UpdatePriceOfProductColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 29, 1, 38, 38, 890, DateTimeKind.Local).AddTicks(3451),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 12, 29, 0, 40, 30, 286, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Product",
                type: "DECIMAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 29, 0, 40, 30, 286, DateTimeKind.Local).AddTicks(8383),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 12, 29, 1, 38, 38, 890, DateTimeKind.Local).AddTicks(3451));

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Product",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL");
        }
    }
}
