using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp1.Migrations
{
    /// <inheritdoc />
    public partial class reporttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientName = table.Column<string>(type: "TEXT", nullable: false),
                    ChiefComplaint = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    IsSurgeryRequired = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfSurgery = table.Column<string>(type: "TEXT", nullable: false),
                    MedicalString = table.Column<string>(type: "TEXT", nullable: false),
                    AnyPastSurgeries = table.Column<bool>(type: "INTEGER", nullable: false),
                    Hospitals = table.Column<string>(type: "TEXT", nullable: false),
                    Years = table.Column<string>(type: "TEXT", nullable: false),
                    Complications = table.Column<string>(type: "TEXT", nullable: false),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: false),
                    AnyMedication = table.Column<bool>(type: "INTEGER", nullable: false),
                    Medications = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportTable_PatientTable_Id",
                        column: x => x.Id,
                        principalTable: "PatientTable",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportTable");
        }
    }
}
