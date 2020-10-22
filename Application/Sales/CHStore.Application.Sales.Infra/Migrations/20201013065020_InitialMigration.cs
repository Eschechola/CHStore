using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Sales.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DiscountPercentage = table.Column<double>(type: "FLOAT", nullable: false),
                    FL_Active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    InitialDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 554, DateTimeKind.Local).AddTicks(4238)),
                    FinalDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 555, DateTimeKind.Local).AddTicks(4535))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true),
            //        Price = table.Column<decimal>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "TransportCompany",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    SiteUrl = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    TrackingUrl = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    ApiUrl = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    FL_Active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    Number = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    Street = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    ZipCode = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    Complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    OpeningTime = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    ClosingTime = table.Column<TimeSpan>(type: "TIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    TransportCompanyId = table.Column<long>(nullable: false),
                    CouponId = table.Column<long>(nullable: false),
                    TotalPrice = table.Column<double>(type: "FLOAT", nullable: false),
                    ProductsPrice = table.Column<double>(type: "FLOAT", nullable: false),
                    FreightPrice = table.Column<double>(type: "FLOAT", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 563, DateTimeKind.Local).AddTicks(5639)),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_TransportCompany_TransportCompanyId",
                        column: x => x.TransportCompanyId,
                        principalTable: "TransportCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Mount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    DateModified = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2020, 10, 13, 3, 50, 20, 564, DateTimeKind.Local).AddTicks(2791)),
                    OrderStatus = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CouponId",
                table: "Order",
                column: "CouponId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_TransportCompanyId",
                table: "Order",
                column: "TransportCompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_OrderId",
                table: "Status",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "TransportCompany");
        }
    }
}
