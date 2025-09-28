using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateFinancialRecordEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancialRecordType",
                table: "FinancialRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialRecordType",
                table: "FinancialRecords");
        }
    }
}
