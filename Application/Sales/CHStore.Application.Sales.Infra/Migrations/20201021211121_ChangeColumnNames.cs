using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Sales.Infra.Migrations
{
    public partial class ChangeColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Voucher_VoucherId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_TransportCompany_TransportCompanyId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "TransportCompany",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TransportCompany",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "TransportCompany",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "TransportCompany",
                newName: "cnpj");

            migrationBuilder.RenameColumn(
                name: "FL_Active",
                table: "TransportCompany",
                newName: "fl_active");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "TransportCompany",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "TransportCompany",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Complement",
                table: "TransportCompany",
                newName: "complement");

            migrationBuilder.RenameColumn(
                name: "TrackingUrl",
                table: "TransportCompany",
                newName: "tracking_url");

            migrationBuilder.RenameColumn(
                name: "ApiUrl",
                table: "TransportCompany",
                newName: "api_url");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "TransportCompany",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "OpeningTime",
                table: "TransportCompany",
                newName: "opening_time");

            migrationBuilder.RenameColumn(
                name: "ClosingTime",
                table: "TransportCompany",
                newName: "closing_time");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Status",
                newName: "order_status");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Status",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order",
                newName: "total_price");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Order",
                newName: "request_date");

            migrationBuilder.RenameColumn(
                name: "ProductsPrice",
                table: "Order",
                newName: "products_price");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Order",
                newName: "payment_method");

            migrationBuilder.RenameColumn(
                name: "FreightPrice",
                table: "Order",
                newName: "freight_price");

            migrationBuilder.RenameColumn(
                name: "FL_Active",
                table: "Voucher",
                newName: "fl_active");

            migrationBuilder.RenameColumn(
                name: "InitialDate",
                table: "Voucher",
                newName: "initial_date");

            migrationBuilder.RenameColumn(
                name: "FinalDate",
                table: "Voucher",
                newName: "final_date");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "Voucher",
                newName: "discount_percentage");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TransportCompany",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "Status",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Status",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(9399),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 962, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "OrderProduct",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Mount",
                table: "OrderProduct",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<long>(
                name: "TransportCompanyId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "VoucherId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Order",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(1739),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 961, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Voucher",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "initial_date",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 714, DateTimeKind.Local).AddTicks(6531),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 952, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "final_date",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 715, DateTimeKind.Local).AddTicks(7302),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 953, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.AddForeignKey(
                name: "fk_coupon_id",
                table: "Order",
                column: "VoucherId",
                principalTable: "Voucher",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "TransportCompany",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TransportCompany",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "TransportCompany",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cnpj",
                table: "TransportCompany",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "fl_active",
                table: "TransportCompany",
                newName: "FL_Active");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "TransportCompany",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "TransportCompany",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "complement",
                table: "TransportCompany",
                newName: "Complement");

            migrationBuilder.RenameColumn(
                name: "tracking_url",
                table: "TransportCompany",
                newName: "TrackingUrl");

            migrationBuilder.RenameColumn(
                name: "WebSiteUrl",
                table: "TransportCompany",
                newName: "SiteUrl");

            migrationBuilder.RenameColumn(
                name: "api_url",
                table: "TransportCompany",
                newName: "ApiUrl");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "TransportCompany",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "opening_time",
                table: "TransportCompany",
                newName: "OpeningTime");

            migrationBuilder.RenameColumn(
                name: "closing_time",
                table: "TransportCompany",
                newName: "ClosingTime");

            migrationBuilder.RenameColumn(
                name: "order_status",
                table: "Status",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                table: "Status",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "total_price",
                table: "Order",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "request_date",
                table: "Order",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "products_price",
                table: "Order",
                newName: "ProductsPrice");

            migrationBuilder.RenameColumn(
                name: "payment_method",
                table: "Order",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "freight_price",
                table: "Order",
                newName: "FreightPrice");

            migrationBuilder.RenameColumn(
                name: "fl_active",
                table: "Voucher",
                newName: "FL_Active");

            migrationBuilder.RenameColumn(
                name: "initial_date",
                table: "Voucher",
                newName: "InitialDate");

            migrationBuilder.RenameColumn(
                name: "final_date",
                table: "Voucher",
                newName: "FinalDate");

            migrationBuilder.RenameColumn(
                name: "discount_percentage",
                table: "Voucher",
                newName: "DiscountPercentage");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TransportCompany",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "Status",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Status",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 962, DateTimeKind.Local).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "OrderProduct",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Mount",
                table: "OrderProduct",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "TransportCompanyId",
                table: "Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "VoucherId",
                table: "Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 961, DateTimeKind.Local).AddTicks(6845),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 725, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Voucher",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 952, DateTimeKind.Local).AddTicks(3629),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 714, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 15, 17, 14, 6, 953, DateTimeKind.Local).AddTicks(4142),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 21, 18, 11, 21, 715, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Voucher_VoucherId",
                table: "Order",
                column: "VoucherId",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_TransportCompany_TransportCompanyId",
                table: "Order",
                column: "TransportCompanyId",
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
        }
    }
}
