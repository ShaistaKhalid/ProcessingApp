using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessingApp.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MyApplication_MyApplicationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MyApplicationId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MyApplication_MyApplicationId",
                table: "AspNetUsers",
                column: "MyApplicationId",
                principalTable: "MyApplication",
                principalColumn: "MyApplicationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MyApplication_MyApplicationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MyApplicationId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MyApplication_MyApplicationId",
                table: "AspNetUsers",
                column: "MyApplicationId",
                principalTable: "MyApplication",
                principalColumn: "MyApplicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
