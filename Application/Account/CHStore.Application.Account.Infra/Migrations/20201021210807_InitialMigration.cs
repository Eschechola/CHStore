using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Account.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    register_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2020, 10, 21, 18, 8, 7, 453, DateTimeKind.Local).AddTicks(3072)),
                    number = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    street = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    zip_code = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    opening_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 11, nullable: false),
                    document_type = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    register_date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2020, 10, 21, 18, 8, 7, 489, DateTimeKind.Local).AddTicks(8946)),
                    number = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    street = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    zip_code = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    opening_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    username = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_X_Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_employee_id = table.Column<long>(type: "BIGINT", nullable: false),
                    fk_permission_id = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_X_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "fk_employee_id",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_X_Permission_Permission_fk_permission_id",
                        column: x => x.fk_permission_id,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_X_Permission_fk_employee_id",
                table: "Employee_X_Permission",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_X_Permission_fk_permission_id",
                table: "Employee_X_Permission",
                column: "fk_permission_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee_X_Permission");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Permission");
        }
    }
}
