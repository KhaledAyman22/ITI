using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyConsoleAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddClientBranchRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchClient",
                columns: table => new
                {
                    BranchesID = table.Column<int>(type: "int", nullable: false),
                    ClientsCID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchClient", x => new { x.BranchesID, x.ClientsCID });
                    table.ForeignKey(
                        name: "FK_BranchClient_Branches_BranchesID",
                        column: x => x.BranchesID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchClient_Clients_ClientsCID",
                        column: x => x.ClientsCID,
                        principalTable: "Clients",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchClient_ClientsCID",
                table: "BranchClient",
                column: "ClientsCID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchClient");
        }
    }
}
