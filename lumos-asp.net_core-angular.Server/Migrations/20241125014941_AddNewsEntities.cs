using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lumos_asp.net_core_angular.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    IdDeposit = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    DepositName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.IdDeposit);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroup);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    IdLog = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.IdLog);
                    table.ForeignKey(
                        name: "FK_Logs_tb_users_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    IdStreet = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.IdStreet);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    SupplierName = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierCnpj = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierContact = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierAddress = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierPhone = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "tb_PreMeasurement",
                columns: table => new
                {
                    IdMeasurement = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PreMeasurement", x => x.IdMeasurement);
                });

            migrationBuilder.CreateTable(
                name: "tb_team",
                columns: table => new
                {
                    IdTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_team", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "TeamContracts",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamContracts", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    IdType = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.IdType);
                    table.ForeignKey(
                        name: "FK_Types_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreMeasurementTeam",
                columns: table => new
                {
                    PreMeasurementsIdMeasurement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsIdTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMeasurementTeam", x => new { x.PreMeasurementsIdMeasurement, x.TeamsIdTeam });
                    table.ForeignKey(
                        name: "FK_PreMeasurementTeam_tb_PreMeasurement_PreMeasurementsIdMeasurement",
                        column: x => x.PreMeasurementsIdMeasurement,
                        principalTable: "tb_PreMeasurement",
                        principalColumn: "IdMeasurement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreMeasurementTeam_tb_team_TeamsIdTeam",
                        column: x => x.TeamsIdTeam,
                        principalTable: "tb_team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    IdMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    MaterialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialBrand = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialPower = table.Column<float>(type: "real", nullable: true),
                    BuyUnit = table.Column<string>(type: "TEXT", nullable: false),
                    RequestUnit = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    StockAvailable = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.IdMaterial);
                    table.ForeignKey(
                        name: "FK_Materials_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "IdDeposit");
                    table.ForeignKey(
                        name: "FK_Materials_Types_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "Types",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    IdContract = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    contract_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contract_doc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contract_value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialIdMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.IdContract);
                    table.ForeignKey(
                        name: "FK_Contracts_Materials_MaterialIdMaterial",
                        column: x => x.MaterialIdMaterial,
                        principalTable: "Materials",
                        principalColumn: "IdMaterial");
                });

            migrationBuilder.CreateTable(
                name: "MaterialReservations",
                columns: table => new
                {
                    IdMaterialReservation = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    StockReservationName = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreMeasurementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "int", nullable: false),
                    QuantityCompleted = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReservations", x => x.IdMaterialReservation);
                    table.ForeignKey(
                        name: "FK_MaterialReservations_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialReservations_tb_PreMeasurement_PreMeasurementId",
                        column: x => x.PreMeasurementId,
                        principalTable: "tb_PreMeasurement",
                        principalColumn: "IdMeasurement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockMovements",
                columns: table => new
                {
                    StockMovementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    StockMovementDescription = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockMovementRefresh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFinishedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InputQuantity = table.Column<int>(type: "int", nullable: false),
                    BuyUnit = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityPackage = table.Column<int>(type: "int", nullable: false),
                    PricePerItem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMovements", x => x.StockMovementId);
                    table.ForeignKey(
                        name: "FK_StockMovements_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "IdMaterial");
                    table.ForeignKey(
                        name: "FK_StockMovements_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                    table.ForeignKey(
                        name: "FK_StockMovements_tb_users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "tb_users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_StockMovements_tb_users_UserFinishedId",
                        column: x => x.UserFinishedId,
                        principalTable: "tb_users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "QuantityAddContracts",
                columns: table => new
                {
                    IdContratoAditivoQuantitativo = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ValorAditivoQuantitativo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityAddContracts", x => x.IdContratoAditivoQuantitativo);
                    table.ForeignKey(
                        name: "FK_QuantityAddContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskContracts",
                columns: table => new
                {
                    IdTarefa = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeRecebida = table.Column<int>(type: "int", nullable: false),
                    QuantidadeExecutada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskContracts", x => x.IdTarefa);
                    table.ForeignKey(
                        name: "FK_TaskContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskContracts_TeamContracts_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TeamContracts",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_items",
                columns: table => new
                {
                    IdItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ItemTotalValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_items", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_tb_items_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_items_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueAddContracts",
                columns: table => new
                {
                    IdContratoAditivoValor = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    valor_aditivo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueAddContracts", x => x.IdContratoAditivoValor);
                    table.ForeignKey(
                        name: "FK_ValueAddContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemStreet",
                columns: table => new
                {
                    ItemsIdItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetsIdStreet = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStreet", x => new { x.ItemsIdItem, x.StreetsIdStreet });
                    table.ForeignKey(
                        name: "FK_ItemStreet_Streets_StreetsIdStreet",
                        column: x => x.StreetsIdStreet,
                        principalTable: "Streets",
                        principalColumn: "IdStreet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStreet_tb_items_ItemsIdItem",
                        column: x => x.ItemsIdItem,
                        principalTable: "tb_items",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MaterialIdMaterial",
                table: "Contracts",
                column: "MaterialIdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStreet_StreetsIdStreet",
                table: "ItemStreet",
                column: "StreetsIdStreet");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialReservations_MaterialId",
                table: "MaterialReservations",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialReservations_PreMeasurementId",
                table: "MaterialReservations",
                column: "PreMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CompanyId",
                table: "Materials",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DepositId",
                table: "Materials",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreMeasurementTeam_TeamsIdTeam",
                table: "PreMeasurementTeam",
                column: "TeamsIdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityAddContracts_ContractId",
                table: "QuantityAddContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_MaterialId",
                table: "StockMovements",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_SupplierId",
                table: "StockMovements",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_UserCreatedId",
                table: "StockMovements",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_UserFinishedId",
                table: "StockMovements",
                column: "UserFinishedId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskContracts_ContractId",
                table: "TaskContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskContracts_TeamId",
                table: "TaskContracts",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_items_ContractId",
                table: "tb_items",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_items_MaterialId",
                table: "tb_items",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_GroupId",
                table: "Types",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueAddContracts_ContractId",
                table: "ValueAddContracts",
                column: "ContractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemStreet");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MaterialReservations");

            migrationBuilder.DropTable(
                name: "PreMeasurementTeam");

            migrationBuilder.DropTable(
                name: "QuantityAddContracts");

            migrationBuilder.DropTable(
                name: "StockMovements");

            migrationBuilder.DropTable(
                name: "TaskContracts");

            migrationBuilder.DropTable(
                name: "ValueAddContracts");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "tb_items");

            migrationBuilder.DropTable(
                name: "tb_PreMeasurement");

            migrationBuilder.DropTable(
                name: "tb_team");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TeamContracts");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
