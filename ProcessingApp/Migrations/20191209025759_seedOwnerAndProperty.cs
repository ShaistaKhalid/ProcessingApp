using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessingApp.Migrations
{
    public partial class seedOwnerAndProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationList_PropertyModel_PropertyId",
                table: "ApplicationList");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyModel_OwnerModel_OwnerId",
                table: "PropertyModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyModel",
                table: "PropertyModel");

            migrationBuilder.RenameTable(
                name: "PropertyModel",
                newName: "PropertyCreateViewModel");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyModel_OwnerId",
                table: "PropertyCreateViewModel",
                newName: "IX_PropertyCreateViewModel_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyCreateViewModel",
                table: "PropertyCreateViewModel",
                column: "PropertyId");

            migrationBuilder.InsertData(
                table: "OwnerModel",
                columns: new[] { "OwnerId", "OwnerName" },
                values: new object[] { 3, "LLC Test" });

            migrationBuilder.InsertData(
                table: "OwnerModel",
                columns: new[] { "OwnerId", "OwnerName" },
                values: new object[] { 4, "Barsukov&Co" });

            migrationBuilder.InsertData(
                table: "PropertyCreateViewModel",
                columns: new[] { "PropertyId", "City", "ImageUrl", "OwnerId", "PropertyAdress", "PropertyName", "PropertyPrice" },
                values: new object[] { 12, "Seed", "", null, "SeedDrive", "SeededHome", 95.5 });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationList_PropertyCreateViewModel_PropertyId",
                table: "ApplicationList",
                column: "PropertyId",
                principalTable: "PropertyCreateViewModel",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCreateViewModel_OwnerModel_OwnerId",
                table: "PropertyCreateViewModel",
                column: "OwnerId",
                principalTable: "OwnerModel",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationList_PropertyCreateViewModel_PropertyId",
                table: "ApplicationList");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCreateViewModel_OwnerModel_OwnerId",
                table: "PropertyCreateViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyCreateViewModel",
                table: "PropertyCreateViewModel");

            migrationBuilder.DeleteData(
                table: "OwnerModel",
                keyColumn: "OwnerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OwnerModel",
                keyColumn: "OwnerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PropertyCreateViewModel",
                keyColumn: "PropertyId",
                keyValue: 12);

            migrationBuilder.RenameTable(
                name: "PropertyCreateViewModel",
                newName: "PropertyModel");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyCreateViewModel_OwnerId",
                table: "PropertyModel",
                newName: "IX_PropertyModel_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyModel",
                table: "PropertyModel",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationList_PropertyModel_PropertyId",
                table: "ApplicationList",
                column: "PropertyId",
                principalTable: "PropertyModel",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyModel_OwnerModel_OwnerId",
                table: "PropertyModel",
                column: "OwnerId",
                principalTable: "OwnerModel",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
