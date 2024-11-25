using lumos_asp.net_core_angular.Server.Models.Auth;
using lumos_asp.net_core_angular.Server.Models.Contract;
using lumos_asp.net_core_angular.Server.Models.Stock;
using lumos_asp.net_core_angular.Server.Models.Execution;
using Microsoft.EntityFrameworkCore;
using lumos_asp.net_core_angular.Server.Models.System;

namespace lumos_asp.net_core_angular.Server.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<RefreshToken> RefreshTokens { get; set; }
        public required DbSet<Role> Roles { get; set; }
        public required DbSet<User> Users { get; set; }
        public required DbSet<Contract> Contracts { get; set; }
        public required DbSet<QuantityAddContract> QuantityAddContracts { get; set; }
        public required DbSet<TaskContract> TaskContracts { get; set; }
        public required DbSet<TeamContract> TeamContracts { get; set; }
        public required DbSet<ValueAddContract> ValueAddContracts { get; set; }

        public required DbSet<Item> Items { get; set; }
        public required DbSet<MaterialReservation> MaterialReservations { get; set; }
        public required DbSet<PreMeasurement> PreMeasurements { get; set; }
        public required DbSet<Street> Streets { get; set; }
        public required DbSet<Team> Teams { get; set; }

        public required DbSet<Company> Companies { get; set; }
        public required DbSet<Deposit> Deposits { get; set; }
        public required DbSet<Group> Groups { get; set; }
        public required DbSet<Material> Materials { get; set; }
        public required DbSet<StockMovement> StockMovements { get; set; }
        public required DbSet<Supplier> Suppliers { get; set; }
        public required DbSet<Models.Stock.Type> Types { get; set; }
        public required DbSet<Log> Logs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>()
                .Property(ur => ur.TokenId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<User>()
                .Property(ur => ur.UserId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Role>()
                .Property(ur => ur.RoleId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Contract>()
                .Property(ur => ur.IdContract)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<QuantityAddContract>()
                .Property(ur => ur.IdContratoAditivoQuantitativo)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<TaskContract>()
                .Property(ur => ur.IdTarefa)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<TeamContract>()
                .Property(ur => ur.TeamId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<ValueAddContract>()
                .Property(ur => ur.IdContratoAditivoValor)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Item>()
                .Property(ur => ur.IdItem)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<MaterialReservation>()
                .Property(ur => ur.IdMaterialReservation)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<PreMeasurement>()
                .Property(ur => ur.IdMeasurement)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Street>()
                .Property(ur => ur.IdStreet)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Team>()
                .Property(ur => ur.IdTeam)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Company>()
                .Property(ur => ur.IdCompany)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Deposit>()
                .Property(ur => ur.IdDeposit)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Group>()
                .Property(ur => ur.IdGroup)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Material>()
                .Property(ur => ur.IdMaterial)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<StockMovement>()
                .Property(ur => ur.StockMovementId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Supplier>()
                .Property(ur => ur.SupplierId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Models.Stock.Type>()
                .Property(ur => ur.IdType)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Log>()
                .Property(ur => ur.IdLog)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir


        }
    }
}