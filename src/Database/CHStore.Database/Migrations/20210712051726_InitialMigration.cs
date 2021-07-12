using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "chs");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    BrandLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 750, DateTimeKind.Local).AddTicks(4610)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 752, DateTimeKind.Local).AddTicks(4208))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 758, DateTimeKind.Local).AddTicks(4662)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 758, DateTimeKind.Local).AddTicks(4904))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    cnpj = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    CNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    document_type = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 761, DateTimeKind.Local).AddTicks(659)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 761, DateTimeKind.Local).AddTicks(871)),
                    name = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    fl_active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    register_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 761, DateTimeKind.Local).AddTicks(1910)),
                    number = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    street = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    zip_code = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    opening_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "TIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    username = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 813, DateTimeKind.Local).AddTicks(3201)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 813, DateTimeKind.Local).AddTicks(3421)),
                    name = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    fl_active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    register_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 813, DateTimeKind.Local).AddTicks(5908)),
                    number = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    street = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    zip_code = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    opening_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "TIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 842, DateTimeKind.Local).AddTicks(9176)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 842, DateTimeKind.Local).AddTicks(9386))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportCompany",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    cnpj = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    phone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    site_url = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    tracking_url = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    api_url = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    fl_active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    number = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    street = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    zip_code = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    opening_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 849, DateTimeKind.Local).AddTicks(8049)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 849, DateTimeKind.Local).AddTicks(8261))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    discount_percentage = table.Column<double>(type: "FLOAT", nullable: false),
                    fl_active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    initial_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 854, DateTimeKind.Local).AddTicks(81)),
                    final_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 854, DateTimeKind.Local).AddTicks(311)),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 853, DateTimeKind.Local).AddTicks(8391)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 853, DateTimeKind.Local).AddTicks(8656))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_category_id = table.Column<long>(type: "BIGINT", nullable: false),
                    fk_brand_id = table.Column<long>(type: "BIGINT", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    stock = table.Column<long>(type: "BIGINT", nullable: false),
                    fl_active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    slug = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    register_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 844, DateTimeKind.Local).AddTicks(9902)),
                    url_image = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    lenght = table.Column<decimal>(type: "DECIMAL", nullable: true),
                    width = table.Column<decimal>(type: "DECIMAL", nullable: true),
                    depth = table.Column<decimal>(type: "DECIMAL", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 844, DateTimeKind.Local).AddTicks(7568)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 844, DateTimeKind.Local).AddTicks(7893))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "fk_brand_id",
                        column: x => x.fk_brand_id,
                        principalSchema: "chs",
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_id",
                        column: x => x.fk_category_id,
                        principalSchema: "chs",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePermissions",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_employee_id = table.Column<long>(type: "BIGINT", nullable: false),
                    fk_permission_id = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 832, DateTimeKind.Local).AddTicks(1259)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 832, DateTimeKind.Local).AddTicks(1554))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "fk_employee_id",
                        column: x => x.fk_employee_id,
                        principalSchema: "chs",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePermissions_Permission_fk_permission_id",
                        column: x => x.fk_permission_id,
                        principalSchema: "chs",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_customer_id = table.Column<long>(type: "BIGINT", nullable: false),
                    fk_transport_company_id = table.Column<long>(type: "BIGINT", nullable: false),
                    fk_coupon_id = table.Column<long>(type: "BIGINT", nullable: false),
                    total_price = table.Column<double>(type: "FLOAT", nullable: false),
                    products_price = table.Column<double>(type: "FLOAT", nullable: false),
                    freight_price = table.Column<double>(type: "FLOAT", nullable: false),
                    request_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 840, DateTimeKind.Local).AddTicks(2605)),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_method = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 835, DateTimeKind.Local).AddTicks(979)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 835, DateTimeKind.Local).AddTicks(1209))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "fk_customer_id",
                        column: x => x.fk_customer_id,
                        principalSchema: "chs",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_TransportCompany_fk_transport_company_id",
                        column: x => x.fk_transport_company_id,
                        principalSchema: "chs",
                        principalTable: "TransportCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Voucher_fk_coupon_id",
                        column: x => x.fk_coupon_id,
                        principalSchema: "chs",
                        principalTable: "Voucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_order_id = table.Column<long>(type: "BIGINT", nullable: false),
                    fk_product_id = table.Column<long>(type: "BIGINT", nullable: false),
                    mount = table.Column<long>(type: "BIGINT", nullable: false, defaultValue: 1L),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 841, DateTimeKind.Local).AddTicks(3416)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 841, DateTimeKind.Local).AddTicks(3626))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_fk_order_id",
                        column: x => x.fk_order_id,
                        principalSchema: "chs",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_fk_product_id",
                        column: x => x.fk_product_id,
                        principalSchema: "chs",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "chs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_order_id = table.Column<long>(type: "BIGINT", nullable: false),
                    date_modified = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 848, DateTimeKind.Local).AddTicks(1284)),
                    order_status = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 848, DateTimeKind.Local).AddTicks(760)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2021, 7, 12, 2, 17, 25, 848, DateTimeKind.Local).AddTicks(1045))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Order_fk_order_id",
                        column: x => x.fk_order_id,
                        principalSchema: "chs",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Id",
                schema: "chs",
                table: "Brand",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                schema: "chs",
                table: "Category",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_cnpj",
                schema: "chs",
                table: "Customer",
                column: "cnpj",
                unique: true,
                filter: "[cnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_cpf",
                schema: "chs",
                table: "Customer",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_email",
                schema: "chs",
                table: "Customer",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                schema: "chs",
                table: "Customer",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_cpf",
                schema: "chs",
                table: "Employee",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_email",
                schema: "chs",
                table: "Employee",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Id",
                schema: "chs",
                table: "Employee",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_username",
                schema: "chs",
                table: "Employee",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_fk_employee_id",
                schema: "chs",
                table: "EmployeePermissions",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_fk_permission_id",
                schema: "chs",
                table: "EmployeePermissions",
                column: "fk_permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_Id",
                schema: "chs",
                table: "EmployeePermissions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_coupon_id",
                schema: "chs",
                table: "Order",
                column: "fk_coupon_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_customer_id",
                schema: "chs",
                table: "Order",
                column: "fk_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_transport_company_id",
                schema: "chs",
                table: "Order",
                column: "fk_transport_company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id",
                schema: "chs",
                table: "Order",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_fk_order_id",
                schema: "chs",
                table: "OrderProduct",
                column: "fk_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_fk_product_id",
                schema: "chs",
                table: "OrderProduct",
                column: "fk_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_Id",
                schema: "chs",
                table: "OrderProduct",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Id",
                schema: "chs",
                table: "Permission",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_fk_brand_id",
                schema: "chs",
                table: "Product",
                column: "fk_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_fk_category_id",
                schema: "chs",
                table: "Product",
                column: "fk_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                schema: "chs",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_fk_order_id",
                schema: "chs",
                table: "Status",
                column: "fk_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Id",
                schema: "chs",
                table: "Status",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportCompany_Id",
                schema: "chs",
                table: "TransportCompany",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_Id",
                schema: "chs",
                table: "Voucher",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePermissions",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "OrderProduct",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "TransportCompany",
                schema: "chs");

            migrationBuilder.DropTable(
                name: "Voucher",
                schema: "chs");
        }
    }
}
