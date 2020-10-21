using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Account.Infra.Migrations
{
    public partial class ChangeFKNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Employee",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 116, DateTimeKind.Local).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 8, 7, 489, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Customer",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 79, DateTimeKind.Local).AddTicks(8716),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 8, 7, 453, DateTimeKind.Local).AddTicks(3072));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Employee",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 8, 7, 489, DateTimeKind.Local).AddTicks(8946),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 116, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Customer",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 8, 7, 453, DateTimeKind.Local).AddTicks(3072),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 35, 26, 79, DateTimeKind.Local).AddTicks(8716));
        }
    }
}
