using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Migrations
{
    public partial class wishlistfkadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WishListID",
                table: "WishList",
                newName: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductID",
                table: "WishList",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserID",
                table: "WishList",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Product_ProductID",
                table: "WishList",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_User_UserID",
                table: "WishList",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Product_ProductID",
                table: "WishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_User_UserID",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_ProductID",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_UserID",
                table: "WishList");

            migrationBuilder.RenameColumn(
                name: "WishListId",
                table: "WishList",
                newName: "WishListID");
        }
    }
}
