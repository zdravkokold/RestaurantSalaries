using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSalaries.Migrations
{
    /// <inheritdoc />
    public partial class salaryCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Дата на получаване",
                table: "Salaries",
                newName: "Изчислена на");

            migrationBuilder.AddColumn<string>(
                name: "Длъжност",
                table: "Salaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Заплата за месец",
                table: "Salaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Име",
                table: "Salaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Длъжност",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Заплата за месец",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Име",
                table: "Salaries");

            migrationBuilder.RenameColumn(
                name: "Изчислена на",
                table: "Salaries",
                newName: "Дата на получаване");
        }
    }
}
