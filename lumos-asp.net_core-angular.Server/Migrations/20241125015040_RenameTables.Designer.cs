﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lumos_asp.net_core_angular.Server.Data;

#nullable disable

namespace lumos_asp.net_core_angular.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125015040_RenameTables")]
    partial class RenameTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemStreet", b =>
                {
                    b.Property<Guid>("ItemsIdItem")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StreetsIdStreet")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemsIdItem", "StreetsIdStreet");

                    b.HasIndex("StreetsIdStreet");

                    b.ToTable("ItemStreet");
                });

            modelBuilder.Entity("PreMeasurementTeam", b =>
                {
                    b.Property<Guid>("PreMeasurementsIdMeasurement")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamsIdTeam")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PreMeasurementsIdMeasurement", "TeamsIdTeam");

                    b.HasIndex("TeamsIdTeam");

                    b.ToTable("PreMeasurementTeam");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesRoleId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Auth.RefreshToken", b =>
                {
                    b.Property<Guid>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Revoked")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Auth.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("RoleEnum")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Auth.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.Contract", b =>
                {
                    b.Property<Guid>("IdContract")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contract_doc");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contract_number");

                    b.Property<decimal?>("ContractValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("contract_value");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_date");

                    b.Property<Guid?>("MaterialIdMaterial")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContract");

                    b.HasIndex("MaterialIdMaterial");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.QuantityAddContract", b =>
                {
                    b.Property<Guid>("IdContratoAditivoQuantitativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("ValorAditivoQuantitativo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdContratoAditivoQuantitativo");

                    b.HasIndex("ContractId");

                    b.ToTable("QuantityAddContracts");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.TaskContract", b =>
                {
                    b.Property<Guid>("IdTarefa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeExecutada")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeRecebida")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdTarefa");

                    b.HasIndex("ContractId");

                    b.HasIndex("TeamId");

                    b.ToTable("TaskContracts");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.TeamContract", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("TeamId");

                    b.ToTable("TeamContracts");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.ValueAddContract", b =>
                {
                    b.Property<Guid>("IdContratoAditivoValor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("ValorAditivo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor_aditivo");

                    b.HasKey("IdContratoAditivoValor");

                    b.HasIndex("ContractId");

                    b.ToTable("ValueAddContracts");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.Item", b =>
                {
                    b.Property<Guid>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemTotalValue")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ItemValue")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdItem");

                    b.HasIndex("ContractId");

                    b.HasIndex("MaterialId");

                    b.ToTable("tb_items");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.MaterialReservation", b =>
                {
                    b.Property<Guid>("IdMaterialReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PreMeasurementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityCompleted")
                        .HasColumnType("int");

                    b.Property<int>("ReservedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StockReservationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdMaterialReservation");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PreMeasurementId");

                    b.ToTable("MaterialReservations");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.PreMeasurement", b =>
                {
                    b.Property<Guid>("IdMeasurement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdMeasurement");

                    b.ToTable("tb_PreMeasurement");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.Street", b =>
                {
                    b.Property<Guid>("IdStreet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdStreet");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.Team", b =>
                {
                    b.Property<Guid>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTeam");

                    b.ToTable("tb_team");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Company", b =>
                {
                    b.Property<Guid>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCompany");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Deposit", b =>
                {
                    b.Property<Guid>("IdDeposit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("DepositName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdDeposit");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Group", b =>
                {
                    b.Property<Guid>("IdGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdGroup");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Material", b =>
                {
                    b.Property<Guid>("IdMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("BuyUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DepositId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Inactive")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialBrand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float?>("MaterialPower")
                        .HasColumnType("real");

                    b.Property<Guid>("MaterialTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RequestUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StockAvailable")
                        .HasColumnType("int");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("IdMaterial");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepositId");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.StockMovement", b =>
                {
                    b.Property<Guid>("StockMovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("BuyUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InputQuantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("MaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("PricePerItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityPackage")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StockMovementDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StockMovementRefresh")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserCreatedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserFinishedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StockMovementId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserFinishedId");

                    b.ToTable("StockMovements");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierCnpj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierContact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Type", b =>
                {
                    b.Property<Guid>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdType");

                    b.HasIndex("GroupId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.System.Log", b =>
                {
                    b.Property<Guid>("IdLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdLog");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ItemStreet", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Execution.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsIdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Execution.Street", null)
                        .WithMany()
                        .HasForeignKey("StreetsIdStreet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PreMeasurementTeam", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Execution.PreMeasurement", null)
                        .WithMany()
                        .HasForeignKey("PreMeasurementsIdMeasurement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Execution.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsIdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Auth.RefreshToken", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Auth.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.Contract", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Material", null)
                        .WithMany("Contracts")
                        .HasForeignKey("MaterialIdMaterial");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.QuantityAddContract", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Contract.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.TaskContract", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Contract.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Contract.TeamContract", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.ValueAddContract", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Contract.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.Item", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Contract.Contract", "Contract")
                        .WithMany("ItemsContract")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Execution.MaterialReservation", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Execution.PreMeasurement", "PreMeasurement")
                        .WithMany()
                        .HasForeignKey("PreMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("PreMeasurement");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Material", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Deposit", "Deposit")
                        .WithMany()
                        .HasForeignKey("DepositId");

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Type", "MaterialType")
                        .WithMany()
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Deposit");

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.StockMovement", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Auth.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Auth.User", "UserFinished")
                        .WithMany()
                        .HasForeignKey("UserFinishedId");

                    b.Navigation("Material");

                    b.Navigation("Supplier");

                    b.Navigation("UserCreated");

                    b.Navigation("UserFinished");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Type", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Stock.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.System.Log", b =>
                {
                    b.HasOne("lumos_asp.net_core_angular.Server.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Auth.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Contract.Contract", b =>
                {
                    b.Navigation("ItemsContract");
                });

            modelBuilder.Entity("lumos_asp.net_core_angular.Server.Models.Stock.Material", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
