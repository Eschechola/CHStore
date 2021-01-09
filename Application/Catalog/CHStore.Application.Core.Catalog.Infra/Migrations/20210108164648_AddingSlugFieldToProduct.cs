using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    public partial class AddingSlugFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 8, 13, 46, 48, 392, DateTimeKind.Local).AddTicks(6251),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 12, 29, 1, 38, 38, 890, DateTimeKind.Local).AddTicks(3451));

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "Product",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slug",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 29, 1, 38, 38, 890, DateTimeKind.Local).AddTicks(3451),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2021, 1, 8, 13, 46, 48, 392, DateTimeKind.Local).AddTicks(6251));
        }
    }
}
