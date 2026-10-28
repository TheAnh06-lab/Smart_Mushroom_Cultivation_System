
using Microsoft.EntityFrameworkCore;
using SmartMushroom_API.Models;

namespace SmartMushroom_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<CultivationTray> CultivationTrays { get; set; } = null!;
        public DbSet<CultivationRoom> CultivationRooms { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasIndex(e => e.RoleName)
                    .IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .IsRequired();

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsRequired();

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsRequired(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.RoleId);
                modelBuilder.Entity<CultivationRoom>(entity =>
                {
                    entity.ToTable("cultivation_rooms");

                    entity.HasKey(e => e.RoomId);

                    entity.Property(e => e.RoomId)
                        .HasColumnName("room_id")
                        .ValueGeneratedOnAdd();

                    entity.Property(e => e.RoomName)
                        .HasColumnName("room_name")
                        .HasMaxLength(100)
                        .IsRequired();

                    entity.Property(e => e.Description)
                        .HasColumnName("description")
                        .HasColumnType("text")
                        .IsRequired(false);

                    entity.Property(e => e.Status)
                        .HasColumnName("status")
                        .HasMaxLength(30)
                        .HasDefaultValue("active")
                        .IsRequired(false);
                    modelBuilder.Entity<CultivationTray>(entity =>
                    {
                        entity.ToTable("cultivation_trays");

                        entity.HasKey(e => e.TrayId);

                        entity.Property(e => e.TrayId)
                            .HasColumnName("tray_id")
                            .ValueGeneratedOnAdd();

                        entity.Property(e => e.RoomId)
                            .HasColumnName("room_id")
                            .IsRequired();

                        entity.Property(e => e.TrayCode)
                            .HasColumnName("tray_code")
                            .HasMaxLength(50)
                            .IsRequired();

                        entity.HasIndex(e => e.TrayCode)
                            .IsUnique();

                        entity.Property(e => e.MushroomType)
                            .HasColumnName("mushroom_type")
                            .HasMaxLength(100)
                            .IsRequired(false);

                        entity.Property(e => e.CultivationStage)
                            .HasColumnName("cultivation_stage")
                            .HasMaxLength(100)
                            .IsRequired(false);

                        entity.Property(e => e.Status)
                            .HasColumnName("status")
                            .HasMaxLength(30)
                            .HasDefaultValue("available")
                            .IsRequired(false);

                        entity.Property(e => e.ExpectedHarvestDate)
                            .HasColumnName("expected_harvest_date")
                            .HasColumnType("date")
                            .IsRequired(false);

                        entity.HasOne(e => e.CultivationRoom)
                            .WithMany()
                            .HasForeignKey(e => e.RoomId);
                    });
                });
            });
        }
    }
}