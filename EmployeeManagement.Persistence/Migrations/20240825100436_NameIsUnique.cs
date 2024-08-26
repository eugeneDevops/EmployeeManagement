using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NameIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateEmployment",
                schema: "EmployeeManagement",
                table: "Employees",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name",
                schema: "EmployeeManagement",
                table: "Employees",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Name",
                schema: "EmployeeManagement",
                table: "Employees");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateEmployment",
                schema: "EmployeeManagement",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
