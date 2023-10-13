using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserandUsercredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserCredential_UserCredentialId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserCredentialId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserCredentialId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserCredentialId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCredentialId",
                table: "User",
                column: "UserCredentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserCredential_UserCredentialId",
                table: "User",
                column: "UserCredentialId",
                principalTable: "UserCredential",
                principalColumn: "UserCredentialId");
        }
    }
}
