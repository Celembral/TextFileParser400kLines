using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changetablesv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeterReadings",
                table: "GasMeter");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "GasMeter",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "GasMeterReadings",
                table: "Data",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "GasMeter");

            migrationBuilder.DropColumn(
                name: "GasMeterReadings",
                table: "Data");

            migrationBuilder.AddColumn<double>(
                name: "MeterReadings",
                table: "GasMeter",
                type: "double precision",
                nullable: true);
        }
    }
}
