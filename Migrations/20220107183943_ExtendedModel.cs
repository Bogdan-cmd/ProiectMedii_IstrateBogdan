using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMediiMaster_BogdanIstrate.Migrations
{
    public partial class ExtendedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReleasedGuitar",
                columns: table => new
                {
                    FactoryID = table.Column<int>(type: "int", nullable: false),
                    GuitarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasedGuitar", x => new { x.GuitarID, x.FactoryID });
                    table.ForeignKey(
                        name: "FK_ReleasedGuitar_Guitar_GuitarID",
                        column: x => x.GuitarID,
                        principalTable: "Guitar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleasedGuitar_Publisher_FactoryID",
                        column: x => x.FactoryID,
                        principalTable: "Publisher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReleasedGuitar_FactoryID",
                table: "ReleasedGuitar",
                column: "FactoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReleasedGuitar");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
