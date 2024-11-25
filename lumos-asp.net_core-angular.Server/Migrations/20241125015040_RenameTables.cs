using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lumos_asp.net_core_angular.Server.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_tb_users_UserId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_tb_roles_RolesRoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_tb_users_UsersUserId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_tb_users_UserCreatedId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_tb_users_UserFinishedId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_refresh_token_tb_users_UserId",
                table: "tb_refresh_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_roles",
                table: "tb_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_refresh_token",
                table: "tb_refresh_token");

            migrationBuilder.RenameTable(
                name: "tb_users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tb_roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tb_refresh_token",
                newName: "RefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_tb_refresh_token_UserId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Users_UserId",
                table: "Logs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RolesRoleId",
                table: "RoleUser",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersUserId",
                table: "RoleUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Users_UserCreatedId",
                table: "StockMovements",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Users_UserFinishedId",
                table: "StockMovements",
                column: "UserFinishedId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Users_UserId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RolesRoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersUserId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Users_UserCreatedId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Users_UserFinishedId",
                table: "StockMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tb_users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_roles");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "tb_refresh_token");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                table: "tb_refresh_token",
                newName: "IX_tb_refresh_token_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_roles",
                table: "tb_roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_refresh_token",
                table: "tb_refresh_token",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_tb_users_UserId",
                table: "Logs",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_tb_roles_RolesRoleId",
                table: "RoleUser",
                column: "RolesRoleId",
                principalTable: "tb_roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_tb_users_UsersUserId",
                table: "RoleUser",
                column: "UsersUserId",
                principalTable: "tb_users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_tb_users_UserCreatedId",
                table: "StockMovements",
                column: "UserCreatedId",
                principalTable: "tb_users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_tb_users_UserFinishedId",
                table: "StockMovements",
                column: "UserFinishedId",
                principalTable: "tb_users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refresh_token_tb_users_UserId",
                table: "tb_refresh_token",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
