using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    public partial class AddingProductSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "size",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 11, 21, 11, 20, 275, DateTimeKind.Local).AddTicks(8133),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 25, 44, 82, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.AddColumn<decimal>(
                name: "lenght",
                table: "Product",
                type: "DECIMAL",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width",
                table: "Product",
                type: "DECIMAL",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lenght",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "width",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 25, 44, 82, DateTimeKind.Local).AddTicks(8554),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 11, 11, 21, 11, 20, 275, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.AddColumn<int>(
                name: "size",
                table: "Product",
                type: "long",
                nullable: false,
                defaultValue: 0);
        }
    }
}
