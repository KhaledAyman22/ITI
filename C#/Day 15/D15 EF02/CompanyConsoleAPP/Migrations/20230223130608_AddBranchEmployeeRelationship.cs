using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyConsoleAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchEmployeeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchID",
                table: "Employees",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_BranchID",
                table: "Employees",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_BranchID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BranchID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Employees");
        }
    }
}
