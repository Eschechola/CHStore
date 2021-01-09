using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    public partial class AddingDepthOfProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 29, 0, 40, 30, 286, DateTimeKind.Local).AddTicks(8383),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 11, 11, 21, 11, 20, 275, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.AddColumn<decimal>(
                name: "depth",
                table: "Product",
                type: "DECIMAL",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "depth",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 11, 21, 11, 20, 275, DateTimeKind.Local).AddTicks(8133),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 12, 29, 0, 40, 30, 286, DateTimeKind.Local).AddTicks(8383));
        }
    }
}
