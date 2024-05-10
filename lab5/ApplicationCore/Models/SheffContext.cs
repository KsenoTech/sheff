using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebSheff.ApplicationCore.Models;

public partial class SheffContext : IdentityDbContext<User>
{
    protected readonly IConfiguration Configuration;

    public SheffContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public virtual DbSet<ProvidedService> ProvidedServices { get; set; }

    public virtual DbSet<Smeta> Smetas { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProvidedService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Type_of_Service");

            entity.ToTable("Provided_Service");

            entity.Property(e => e.CostOfM).HasColumnName("cost_of_m");
            entity.Property(e => e.CostOfM2).HasColumnName("cost_of_m2");
        });

        modelBuilder.Entity<Smeta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Zakaz");

            entity.Property(e => e.CanIdoIt).HasColumnName("canIdoIt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FeedbackText).HasColumnName("feedback_text");
            entity.Property(e => e.GeneralBudget).HasColumnName("general_budget");
            entity.Property(e => e.IdClient).HasColumnName("Id_client");
            entity.Property(e => e.IdExecutor).HasColumnName("Id_executor");
            entity.Property(e => e.TimeOrder)
                .HasColumnType("datetime")
                .HasColumnName("time_order");

            entity.HasMany(d => d.IdProvededServices).WithMany(p => p.IdSmeta)
                .UsingEntity<Dictionary<string, object>>(
                    "SmetaOrder",
                    r => r.HasOne<ProvidedService>().WithMany()
                        .HasForeignKey("IdProvededService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SmetaOrder_Provided_Service"),
                    l => l.HasOne<Smeta>().WithMany()
                        .HasForeignKey("IdSmeta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SmetaOrder_Smeta"),
                    j =>
                    {
                        j.HasKey("IdSmeta", "IdProvededService");
                        j.ToTable("SmetaOrder");
                        j.HasIndex(new[] { "IdProvededService" }, "IX_SmetaOrder_Id_Proveded_Service");
                        j.IndexerProperty<int>("IdSmeta").HasColumnName("Id_Smeta");
                        j.IndexerProperty<int>("IdProvededService").HasColumnName("Id_Proveded_Service");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email).HasColumnName("e_mail");
            entity.Property(e => e.KolvoZakazov).HasColumnName("kolvoZakazov").IsRequired(false);
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Rating).HasColumnName("rating").IsRequired(false);
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.TelephoneNumber).HasColumnName("telephone_number");

            entity.HasMany(d => d.ProvidedServices).WithMany(p => p.IdExecutors)
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
                        j.IndexerProperty<int>("IdExecutor").HasColumnName("Id_executor");
                        j.IndexerProperty<int>("TypeOfService").HasColumnName("Type_of_Service");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
