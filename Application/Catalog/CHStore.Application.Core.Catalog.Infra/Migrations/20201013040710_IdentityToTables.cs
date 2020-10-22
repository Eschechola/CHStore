using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    public partial class IdentityToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 13, 1, 7, 9, 984, DateTimeKind.Local).AddTicks(6993),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 7, 18, 27, 23, 70, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "biglong");

            migrationBuilder.AlterColumn<long>(
                name: "BrandId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "biglong");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Product",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "biglong")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Category",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "biglong")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Brand",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "biglong")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Product",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 7, 18, 27, 23, 70, DateTimeKind.Local).AddTicks(1397),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 13, 1, 7, 9, 984, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Product",
                type: "biglong",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "BrandId",
                table: "Product",
                type: "biglong",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Product",
                type: "biglong",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Category",
                type: "biglong",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Brand",
                type: "biglong",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
