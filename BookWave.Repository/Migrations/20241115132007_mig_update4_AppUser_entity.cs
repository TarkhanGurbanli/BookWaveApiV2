using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWave.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig_update4_AppUser_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUsers_ImageId",
                table: "AppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_ImageId",
                table: "AppUsers",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUsers_ImageId",
                table: "AppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_ImageId",
                table: "AppUsers",
                column: "ImageId",
                unique: true);
        }
    }
}
