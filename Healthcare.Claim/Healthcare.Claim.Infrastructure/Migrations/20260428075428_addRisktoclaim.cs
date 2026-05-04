using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareClaim.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRisktoclaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RiskLevel",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RiskScore",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiskLevel",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "RiskScore",
                table: "Claims");
        }
    }
}
