using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Sales.Infra.Migrations
{
    public partial class ChangeUserToCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_UserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 962, DateTimeKind.Local).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 257, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 961, DateTimeKind.Local).AddTicks(6845),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 256, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Order",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 952, DateTimeKind.Local).AddTicks(3629),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 247, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 953, DateTimeKind.Local).AddTicks(4142),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 248, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 257, DateTimeKind.Local).AddTicks(5053),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 962, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 256, DateTimeKind.Local).AddTicks(7484),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 961, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 247, DateTimeKind.Local).AddTicks(5091),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 952, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 248, DateTimeKind.Local).AddTicks(5223),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 953, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
