using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserProductDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductDetail_Products_ProductId",
                table: "UserProductDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProductDetail_Users_UserId",
                table: "UserProductDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProductDetail",
                table: "UserProductDetail");

            migrationBuilder.RenameTable(
                name: "UserProductDetail",
                newName: "UserProductDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserProductDetail_UserId",
                table: "UserProductDetails",
                newName: "IX_UserProductDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProductDetails",
                table: "UserProductDetails",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductDetails_Products_ProductId",
                table: "UserProductDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductDetails_Users_UserId",
                table: "UserProductDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductDetails_Products_ProductId",
                table: "UserProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProductDetails_Users_UserId",
                table: "UserProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProductDetails",
                table: "UserProductDetails");

            migrationBuilder.RenameTable(
                name: "UserProductDetails",
                newName: "UserProductDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserProductDetails_UserId",
                table: "UserProductDetail",
                newName: "IX_UserProductDetail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProductDetail",
                table: "UserProductDetail",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductDetail_Products_ProductId",
                table: "UserProductDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductDetail_Users_UserId",
                table: "UserProductDetail",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
