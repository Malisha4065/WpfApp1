using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp1.Migrations
{
    /// <inheritdoc />
    public partial class compositekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportTable_DoctorTable_DoctorID",
                table: "ReportTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTable",
                table: "ReportTable");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "ReportTable",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTable_DoctorID",
                table: "ReportTable",
                newName: "IX_ReportTable_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTable",
                table: "ReportTable",
                columns: new[] { "Id", "DoctorId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportTable_Id",
                table: "ReportTable",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTable_DoctorTable_DoctorId",
                table: "ReportTable",
                column: "DoctorId",
                principalTable: "DoctorTable",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportTable_DoctorTable_DoctorId",
                table: "ReportTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTable",
                table: "ReportTable");

            migrationBuilder.DropIndex(
                name: "IX_ReportTable_Id",
                table: "ReportTable");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "ReportTable",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTable_DoctorId",
                table: "ReportTable",
                newName: "IX_ReportTable_DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTable",
                table: "ReportTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTable_DoctorTable_DoctorID",
                table: "ReportTable",
                column: "DoctorID",
                principalTable: "DoctorTable",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
