using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManagementMVC.Migrations
{
    /// <inheritdoc />
    public partial class addedFKInTwoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Shifts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Shifts");
        }
    }
}
