using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMediiMaster_BogdanIstrate.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "GuitarOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuitarOrder_ReviewId",
                table: "GuitarOrder",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarOrder_Review_ReviewId",
                table: "GuitarOrder",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarOrder_Review_ReviewId",
                table: "GuitarOrder");

            migrationBuilder.DropIndex(
                name: "IX_GuitarOrder_ReviewId",
                table: "GuitarOrder");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "GuitarOrder");
        }
    }
}
