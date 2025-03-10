using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSalaries.Migrations
{
    /// <inheritdoc />
    public partial class SalaryField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Salaries");

            migrationBuilder.AddColumn<decimal>(
                name: "Заплата",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Заплата",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Salaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
