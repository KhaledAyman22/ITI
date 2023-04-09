using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanHospitalSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformanceRate = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssuePatient",
                columns: table => new
                {
                    IssuesId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuePatient", x => new { x.IssuesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_IssuePatient_Issues_IssuesId",
                        column: x => x.IssuesId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuePatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specialization" },
                values: new object[,]
                {
                    { 1, "Jessie", 65, 27064m, "Hematology" },
                    { 2, "Judy", 32, 18711m, "Neurology" },
                    { 3, "Naomi", 27, 32145m, "Pediatrics" },
                    { 4, "Joann", 72, 9232m, "Hematology" },
                    { 5, "Judy", 19, 48498m, "Dermatology" },
                    { 6, "Alyssa", 79, 16586m, "Gastroenterology" },
                    { 7, "Mable", 5, 33706m, "Infectious Disease" },
                    { 8, "Paula", 0, 19094m, "Urology" },
                    { 9, "Rafael", 97, 12266m, "Pediatrics" },
                    { 10, "Sara", 82, 45041m, "Pediatrics" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Diabetes" },
                    { 2, "Hypertension" },
                    { 3, "Asthma" },
                    { 4, "Depression" },
                    { 5, "Arthritis" },
                    { 6, "Allergy" },
                    { 7, "Flu" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DoctorId", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Dana" },
                    { 2, 7, "Isaac" },
                    { 3, 9, "Damon" },
                    { 4, 8, "Miriam" },
                    { 5, 7, "Terence" },
                    { 6, 1, "Roosevelt" },
                    { 7, 9, "Eduardo" },
                    { 8, 8, "Wilbert" },
                    { 9, 5, "Tasha" },
                    { 10, 1, "Max" },
                    { 11, 2, "Bridget" },
                    { 12, 8, "Juan" },
                    { 13, 10, "Krystal" },
                    { 14, 10, "Erma" },
                    { 15, 6, "Orlando" },
                    { 16, 5, "Marvin" },
                    { 17, 4, "Lamar" },
                    { 18, 7, "Joe" },
                    { 19, 8, "Wendell" },
                    { 20, 4, "Sandra" },
                    { 21, 6, "Stephanie" },
                    { 22, 7, "Ervin" },
                    { 23, 4, "Beth" },
                    { 24, 7, "Gretchen" },
                    { 25, 2, "Gwendolyn" },
                    { 26, 7, "Jerry" },
                    { 27, 6, "Mitchell" },
                    { 28, 8, "Maggie" },
                    { 29, 3, "Sandy" },
                    { 30, 2, "Lloyd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssuePatient_PatientsId",
                table: "IssuePatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuePatient");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
