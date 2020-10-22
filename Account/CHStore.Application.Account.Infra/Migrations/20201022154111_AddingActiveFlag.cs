using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Account.Infra.Migrations
{
    public partial class AddingActiveFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Employee",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 822, DateTimeKind.Local).AddTicks(2683),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 116, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Customer",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 786, DateTimeKind.Local).AddTicks(3055),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 79, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.AddColumn<bool>(
                name: "fl_active",
                table: "Customer",
                type: "BIT",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fl_active",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Employee",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 116, DateTimeKind.Local).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 822, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Customer",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 79, DateTimeKind.Local).AddTicks(8716),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 786, DateTimeKind.Local).AddTicks(3055));
        }
    }
}
