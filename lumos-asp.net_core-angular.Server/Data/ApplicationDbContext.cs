using lumos_asp.net_core_angular.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace lumos_asp.net_core_angular.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a geração do Guid usando NEWID() no banco de dados
            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.UserRoleId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<RefreshToken>()
                .Property(ur => ur.TokenId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<User>()
                .Property(ur => ur.UserId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir

            modelBuilder.Entity<Role>()
                .Property(ur => ur.RoleId)
                .HasDefaultValueSql("NEWID()");  // Gera um GUID único ao inserir
        }
    }
}