using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lumos_asp.net_core_angular.Server.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemStreet_tb_items_ItemsIdItem",
                table: "ItemStreet");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialReservations_tb_PreMeasurement_PreMeasurementId",
                table: "MaterialReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_PreMeasurementTeam_tb_PreMeasurement_PreMeasurementsIdMeasurement",
                table: "PreMeasurementTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PreMeasurementTeam_tb_team_TeamsIdTeam",
                table: "PreMeasurementTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_items_Contracts_ContractId",
                table: "tb_items");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_items_Materials_MaterialId",
                table: "tb_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_team",
                table: "tb_team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_PreMeasurement",
                table: "tb_PreMeasurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_items",
                table: "tb_items");

            migrationBuilder.RenameTable(
                name: "tb_team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "tb_PreMeasurement",
                newName: "PreMeasurements");

            migrationBuilder.RenameTable(
                name: "tb_items",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_tb_items_MaterialId",
                table: "Items",
                newName: "IX_Items_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_items_ContractId",
                table: "Items",
                newName: "IX_Items_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "IdTeam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreMeasurements",
                table: "PreMeasurements",
                column: "IdMeasurement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "IdItem");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Contracts_ContractId",
                table: "Items",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "IdContract",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Materials_MaterialId",
                table: "Items",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "IdMaterial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStreet_Items_ItemsIdItem",
                table: "ItemStreet",
                column: "ItemsIdItem",
                principalTable: "Items",
                principalColumn: "IdItem",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialReservations_PreMeasurements_PreMeasurementId",
                table: "MaterialReservations",
                column: "PreMeasurementId",
                principalTable: "PreMeasurements",
                principalColumn: "IdMeasurement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreMeasurementTeam_PreMeasurements_PreMeasurementsIdMeasurement",
                table: "PreMeasurementTeam",
                column: "PreMeasurementsIdMeasurement",
                principalTable: "PreMeasurements",
                principalColumn: "IdMeasurement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreMeasurementTeam_Teams_TeamsIdTeam",
                table: "PreMeasurementTeam",
                column: "TeamsIdTeam",
                principalTable: "Teams",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Contracts_ContractId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Materials_MaterialId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStreet_Items_ItemsIdItem",
                table: "ItemStreet");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialReservations_PreMeasurements_PreMeasurementId",
                table: "MaterialReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_PreMeasurementTeam_PreMeasurements_PreMeasurementsIdMeasurement",
                table: "PreMeasurementTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PreMeasurementTeam_Teams_TeamsIdTeam",
                table: "PreMeasurementTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreMeasurements",
                table: "PreMeasurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "tb_team");

            migrationBuilder.RenameTable(
                name: "PreMeasurements",
                newName: "tb_PreMeasurement");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "tb_items");

            migrationBuilder.RenameIndex(
                name: "IX_Items_MaterialId",
                table: "tb_items",
                newName: "IX_tb_items_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ContractId",
                table: "tb_items",
                newName: "IX_tb_items_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_team",
                table: "tb_team",
                column: "IdTeam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_PreMeasurement",
                table: "tb_PreMeasurement",
                column: "IdMeasurement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_items",
                table: "tb_items",
                column: "IdItem");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStreet_tb_items_ItemsIdItem",
                table: "ItemStreet",
                column: "ItemsIdItem",
                principalTable: "tb_items",
                principalColumn: "IdItem",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialReservations_tb_PreMeasurement_PreMeasurementId",
                table: "MaterialReservations",
                column: "PreMeasurementId",
                principalTable: "tb_PreMeasurement",
                principalColumn: "IdMeasurement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreMeasurementTeam_tb_PreMeasurement_PreMeasurementsIdMeasurement",
                table: "PreMeasurementTeam",
                column: "PreMeasurementsIdMeasurement",
                principalTable: "tb_PreMeasurement",
                principalColumn: "IdMeasurement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreMeasurementTeam_tb_team_TeamsIdTeam",
                table: "PreMeasurementTeam",
                column: "TeamsIdTeam",
                principalTable: "tb_team",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_items_Contracts_ContractId",
                table: "tb_items",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "IdContract",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_items_Materials_MaterialId",
                table: "tb_items",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "IdMaterial",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
