using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManagementMVC.Migrations
{
    /// <inheritdoc />
    public partial class NewModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NowShowingId",
                table: "Shifts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NowShowingId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NowShowingId",
                table: "Halls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NowShowing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NowShowing", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_NowShowingId",
                table: "Shifts",
                column: "NowShowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_NowShowingId",
                table: "Movies",
                column: "NowShowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_NowShowingId",
                table: "Halls",
                column: "NowShowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_NowShowing_NowShowingId",
                table: "Halls",
                column: "NowShowingId",
                principalTable: "NowShowing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_NowShowing_NowShowingId",
                table: "Movies",
                column: "NowShowingId",
                principalTable: "NowShowing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_NowShowing_NowShowingId",
                table: "Shifts",
                column: "NowShowingId",
                principalTable: "NowShowing",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_NowShowing_NowShowingId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_NowShowing_NowShowingId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_NowShowing_NowShowingId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "NowShowing");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_NowShowingId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Movies_NowShowingId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Halls_NowShowingId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "NowShowingId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "NowShowingId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "NowShowingId",
                table: "Halls");
        }
    }
}
