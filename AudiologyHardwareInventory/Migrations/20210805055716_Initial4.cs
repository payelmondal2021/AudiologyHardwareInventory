using Microsoft.EntityFrameworkCore.Migrations;

namespace AudiologyHardwareInventory.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagesImageUrlId",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ImagesImageUrlId",
                table: "Team",
                column: "ImagesImageUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Images_ImagesImageUrlId",
                table: "Team",
                column: "ImagesImageUrlId",
                principalTable: "Images",
                principalColumn: "ImageUrlId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Images_ImagesImageUrlId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_ImagesImageUrlId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ImagesImageUrlId",
                table: "Team");
        }
    }
}
