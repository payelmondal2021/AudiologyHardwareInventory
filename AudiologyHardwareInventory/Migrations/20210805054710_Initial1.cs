using Microsoft.EntityFrameworkCore.Migrations;

namespace AudiologyHardwareInventory.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hardware",
                columns: table => new
                {
                    HardwareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardwareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagesImageUrlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware", x => x.HardwareId);
                    table.ForeignKey(
                        name: "FK_Hardware_Images_ImagesImageUrlId",
                        column: x => x.ImagesImageUrlId,
                        principalTable: "Images",
                        principalColumn: "ImageUrlId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hardware_ImagesImageUrlId",
                table: "Hardware",
                column: "ImagesImageUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hardware");
        }
    }
}
