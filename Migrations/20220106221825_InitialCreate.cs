using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMediiMaster_BogdanIstrate.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCustomer",
                columns: table => new
                {
                    AppCustomerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCustomer", x => x.AppCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Guitar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guitar_AppCustomer_AppCustomerId",
                        column: x => x.AppCustomerId,
                        principalTable: "AppCustomer",
                        principalColumn: "AppCustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuitarOrder",
                columns: table => new
                {
                    GuitarOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppCustomerId = table.Column<int>(type: "int", nullable: false),
                    GuitarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarOrder", x => x.GuitarOrderId);
                    table.ForeignKey(
                        name: "FK_GuitarOrder_AppCustomer_AppCustomerId",
                        column: x => x.AppCustomerId,
                        principalTable: "AppCustomer",
                        principalColumn: "AppCustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuitarOrder_Guitar_GuitarId",
                        column: x => x.GuitarId,
                        principalTable: "Guitar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarId = table.Column<int>(type: "int", nullable: false),
                    AppCustomerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_AppCustomer_AppCustomerId",
                        column: x => x.AppCustomerId,
                        principalTable: "AppCustomer",
                        principalColumn: "AppCustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Guitar_GuitarId",
                        column: x => x.GuitarId,
                        principalTable: "Guitar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guitar_AppCustomerId",
                table: "Guitar",
                column: "AppCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarOrder_AppCustomerId",
                table: "GuitarOrder",
                column: "AppCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarOrder_GuitarId",
                table: "GuitarOrder",
                column: "GuitarId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_AppCustomerId",
                table: "Review",
                column: "AppCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_GuitarId",
                table: "Review",
                column: "GuitarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuitarOrder");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Guitar");

            migrationBuilder.DropTable(
                name: "AppCustomer");
        }
    }
}
