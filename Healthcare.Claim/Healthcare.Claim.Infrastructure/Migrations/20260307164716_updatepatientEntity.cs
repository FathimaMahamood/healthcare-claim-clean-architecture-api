using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareClaim.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatepatientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderType",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderType",
                table: "Patients");
        }
    }
}
