using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Sales.Infra.Migrations
{
    public partial class ChangeCustomerTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 257, DateTimeKind.Local).AddTicks(5053),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 564, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 256, DateTimeKind.Local).AddTicks(7484),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 563, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 247, DateTimeKind.Local).AddTicks(5091),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 554, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 248, DateTimeKind.Local).AddTicks(5223),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 555, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_UserId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Status",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 564, DateTimeKind.Local).AddTicks(2791),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 257, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "Order",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 563, DateTimeKind.Local).AddTicks(5639),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 256, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 554, DateTimeKind.Local).AddTicks(4238),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 247, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Voucher",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 555, DateTimeKind.Local).AddTicks(4535),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 14, 15, 7, 47, 248, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
