using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyConsoleAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeClientRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeClient",
                columns: table => new
                {
                    EmployeeEID = table.Column<int>(type: "int", nullable: false),
                    ClientCID = table.Column<int>(type: "int", nullable: false),
                    Visit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClient", x => new { x.ClientCID, x.EmployeeEID });
                    table.ForeignKey(
                        name: "FK_EmployeeClient_Clients_ClientCID",
                        column: x => x.ClientCID,
                        principalTable: "Clients",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClient_Employees_EmployeeEID",
                        column: x => x.EmployeeEID,
                        principalTable: "Employees",
                        principalColumn: "EId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClient_EmployeeEID",
                table: "EmployeeClient",
                column: "EmployeeEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeClient");
        }
    }
}
