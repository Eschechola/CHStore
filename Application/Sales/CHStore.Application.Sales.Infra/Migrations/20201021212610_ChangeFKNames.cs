using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Sales.Infra.Migrations
{
    public partial class ChangeFKNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_coupon_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "fk_transport_company_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "fk_order_id",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Order_OrderId",
                table: "Status");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Status",
                newName: "fk_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_Status_OrderId",
                table: "Status",
                newName: "IX_Status_fk_order_id");

            migrationBuilder.RenameColumn(
                name: "TransportCompanyId",
                table: "Order",
                newName: "fk_transport_company_id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Order",
                newName: "fk_customer_id");

            migrationBuilder.RenameColumn(
                name: "VoucherId",
                table: "Order",
                newName: "fk_coupon_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TransportCompanyId",
                table: "Order",
                newName: "IX_Order_fk_transport_company_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                newName: "IX_Order_fk_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_VoucherId",
                table: "Order",
                newName: "IX_Order_fk_coupon_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 195, DateTimeKind.Local).AddTicks(3335),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 194, DateTimeKind.Local).AddTicks(4927),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.AlterColumn<long>(
                name: "fk_customer_id",
                table: "Order",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "initial_date",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(5876),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 714, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "final_date",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 185, DateTimeKind.Local).AddTicks(6847),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 715, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Voucher_fk_coupon_id",
                table: "Order",
                column: "fk_coupon_id",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_fk_customer_id",
                table: "Order",
                column: "fk_customer_id",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_TransportCompany_fk_transport_company_id",
                table: "Order",
                column: "fk_transport_company_id",
                principalTable: "TransportCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Order_fk_order_id",
                table: "Status",
                column: "fk_order_id",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Voucher_fk_coupon_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_fk_customer_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_TransportCompany_fk_transport_company_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Order_fk_order_id",
                table: "Status");

            migrationBuilder.RenameColumn(
                name: "site_url",
                table: "TransportCompany",
                newName: "WebSiteUrl");

            migrationBuilder.RenameColumn(
                name: "fk_order_id",
                table: "Status",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Status_fk_order_id",
                table: "Status",
                newName: "IX_Status_OrderId");

            migrationBuilder.RenameColumn(
                name: "fk_transport_company_id",
                table: "Order",
                newName: "TransportCompanyId");

            migrationBuilder.RenameColumn(
                name: "fk_customer_id",
                table: "Order",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "fk_coupon_id",
                table: "Order",
                newName: "VoucherId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_fk_transport_company_id",
                table: "Order",
                newName: "IX_Order_TransportCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_fk_customer_id",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_fk_coupon_id",
                table: "Order",
                newName: "IX_Order_VoucherId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(9399),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 195, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(1739),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 194, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "initial_date",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 714, DateTimeKind.Local).AddTicks(6531),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "final_date",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 715, DateTimeKind.Local).AddTicks(7302),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 26, 10, 185, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.AddForeignKey(
                name: "fk_coupon_id",
                table: "Order",
                column: "VoucherId",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transport_company_id",
                table: "Order",
                column: "TransportCompanyId",
                principalTable: "TransportCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_id",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Order_OrderId",
                table: "Status",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
