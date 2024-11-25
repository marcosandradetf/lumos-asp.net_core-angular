using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lumos_asp.net_core_angular.Server.Migrations
{
    /// <inheritdoc />
    public partial class ImproveManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_users_roles");

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesRoleId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_RoleUser_tb_roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "tb_roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_tb_users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "tb_users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersUserId",
                table: "RoleUser",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.CreateTable(
                name: "tb_users_roles",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users_roles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_tb_users_roles_tb_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_users_roles_tb_users_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_roles_RoleId",
                table: "tb_users_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_roles_UserId",
                table: "tb_users_roles",
                column: "UserId");
        }
    }
}
