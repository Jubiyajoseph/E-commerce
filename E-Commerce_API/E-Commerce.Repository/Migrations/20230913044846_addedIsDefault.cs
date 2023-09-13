using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Migrations
{
    public partial class addedIsDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultAddress");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Address");

            migrationBuilder.CreateTable(
                name: "DefaultAddress",
                columns: table => new
                {
                    DefaultAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAddress", x => x.DefaultAddressId);
                    table.ForeignKey(
                        name: "FK_DefaultAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultAddress_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAddress_AddressId",
                table: "DefaultAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAddress_UserId",
                table: "DefaultAddress",
                column: "UserId");
        }
    }
}
