using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplySync.Migrations
{
    /// <inheritdoc />
    public partial class FixContractRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserID_RoleID",
                table: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseOrder",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Draft",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Delivery",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Shipped",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID_RoleID",
                table: "UserRole",
                columns: new[] { "UserID", "RoleID" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserID_RoleID",
                table: "UserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseOrder",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Draft");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Delivery",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Shipped");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID_RoleID",
                table: "UserRole",
                columns: new[] { "UserID", "RoleID" },
                unique: true);
        }
    }
}
