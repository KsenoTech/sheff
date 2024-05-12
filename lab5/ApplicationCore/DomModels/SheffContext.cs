using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebSheff.ApplicationCore.DomModels;

public partial class SheffContext : IdentityDbContext<User>
{
    protected readonly IConfiguration Configuration;

    public SheffContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ProvidedService> ProvidedServices { get; set; }

    public virtual DbSet<Smetum> Smeta { get; set; }

    public virtual DbSet<User> Useras { get; set; }

    public virtual DbSet<VidRabot> VidRabots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            //entity.HasNoKey();
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");
            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdClient).HasMaxLength(450);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");

            entity.HasOne(d => d.IdSmetaNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdSmeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Smeta");
        });

        modelBuilder.Entity<ProvidedService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Type_of_Service");

            entity.ToTable("Provided_Service");

            entity.Property(e => e.CostOfM).HasColumnName("cost_of_m");
            entity.Property(e => e.CostOfM2).HasColumnName("cost_of_m2");
        });

        modelBuilder.Entity<Smetum>(entity =>
        {
            entity.Property(e => e.CanIdoIt).HasColumnName("canIdoIt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FeedbackText).HasColumnName("feedback_text");
            entity.Property(e => e.GeneralBudget).HasColumnName("general_budget");
            entity.Property(e => e.IdExecutor)
                .HasMaxLength(450)
                .HasColumnName("Id_executor");
            entity.Property(e => e.TimeOrder)
                .HasColumnType("datetime")
                .HasColumnName("time_order");

            entity.HasMany(d => d.IdProvidedServices).WithMany(p => p.IdSmeta)
                .UsingEntity<Dictionary<string, object>>(
                    "SmetaProvidedService",
                    r => r.HasOne<ProvidedService>().WithMany()
                        .HasForeignKey("IdProvidedService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SmetaProvidedService_Provided_Service"),
                    l => l.HasOne<Smetum>().WithMany()
                        .HasForeignKey("IdSmeta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SmetaOrder_Smeta"),
                    j =>
                    {
                        j.HasKey("IdSmeta", "IdProvidedService").HasName("PK_SmetaOrder");
                        j.ToTable("SmetaProvidedService");
                        j.HasIndex(new[] { "IdProvidedService" }, "IX_SmetaOrder_Id_Proveded_Service");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.EMail)
                .HasMaxLength(256)
                .HasColumnName("e_mail");
            entity.Property(e => e.KolvoZakazov).HasColumnName("kolvoZakazov");
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.TelephoneNumber).HasColumnName("telephone_number");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });

            entity.HasMany(d => d.TypeOfServices).WithMany(p => p.IdExecutors)
                .UsingEntity<Dictionary<string, object>>(
                    "VidRabot",
                    r => r.HasOne<ProvidedService>().WithMany()
                        .HasForeignKey("TypeOfService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VidRabot_Provided_Service"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdExecutor")
                        .HasConstraintName("FK_VidRabot_User1"),
                    j =>
                    {
                        j.HasKey("IdExecutor", "TypeOfService");
                        j.ToTable("VidRabot");
                        j.HasIndex(new[] { "TypeOfService" }, "IX_VidRabot_Type_of_Service");
                        j.IndexerProperty<string>("IdExecutor").HasColumnName("Id_executor");
                        j.IndexerProperty<int>("TypeOfService").HasColumnName("Type_of_Service");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
