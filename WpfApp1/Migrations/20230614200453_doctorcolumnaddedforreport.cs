using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp1.Migrations
{
    /// <inheritdoc />
    public partial class doctorcolumnaddedforreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "ReportTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTable_DoctorID",
                table: "ReportTable",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTable_DoctorTable_DoctorID",
                table: "ReportTable",
                column: "DoctorID",
                principalTable: "DoctorTable",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportTable_DoctorTable_DoctorID",
                table: "ReportTable");

            migrationBuilder.DropIndex(
                name: "IX_ReportTable_DoctorID",
                table: "ReportTable");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "ReportTable");
        }
    }
}
