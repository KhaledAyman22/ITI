using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyConsoleAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeEntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Salary = table.Column<decimal>(type: "Money", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
