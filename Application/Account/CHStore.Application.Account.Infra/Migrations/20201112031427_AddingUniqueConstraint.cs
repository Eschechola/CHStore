using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHStore.Application.Account.Infra.Migrations
{
    public partial class AddingUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Employee",
                newName: "cpf");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Employee",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 12, 0, 14, 26, 928, DateTimeKind.Local).AddTicks(6996),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 822, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Employee",
                type: "VARCHAR(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "fl_active",
                table: "Employee",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Customer",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 12, 0, 14, 26, 890, DateTimeKind.Local).AddTicks(4697),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 786, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Customer",
                type: "VARCHAR(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "Customer",
                type: "VARCHAR(14)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 11);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_cpf",
                table: "Employee",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_email",
                table: "Employee",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_username",
                table: "Employee",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_cnpj",
                table: "Customer",
                column: "cnpj",
                unique: true,
                filter: "[cnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_cpf",
                table: "Customer",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_email",
                table: "Customer",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_cpf",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_email",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_username",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Customer_cnpj",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_cpf",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "fl_active",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Employee",
                newName: "CPF");

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Employee",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 822, DateTimeKind.Local).AddTicks(2683),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 11, 12, 0, 14, 26, 928, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_date",
                table: "Customer",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 22, 12, 41, 10, 786, DateTimeKind.Local).AddTicks(3055),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2020, 11, 12, 0, 14, 26, 890, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Customer",
                type: "VARCHAR(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "Customer",
                type: "VARCHAR(14)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
