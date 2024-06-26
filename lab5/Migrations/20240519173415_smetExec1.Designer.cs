﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSheff.ApplicationCore.DomModels;

#nullable disable

namespace WebSheff.Migrations
{
    [DbContext(typeof(SheffContext))]
    [Migration("20240519173415_smetExec1")]
    partial class smetExec1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SmetaProvidedService", b =>
                {
                    b.Property<int>("IdSmeta")
                        .HasColumnType("int");

                    b.Property<int>("IdProvidedService")
                        .HasColumnType("int");

                    b.HasKey("IdSmeta", "IdProvidedService")
                        .HasName("PK_SmetaOrder");

                    b.HasIndex(new[] { "IdProvidedService" }, "IX_SmetaOrder_Id_Proveded_Service");

                    b.ToTable("SmetaProvidedService", (string)null);
                });

            modelBuilder.Entity("VidRabot", b =>
                {
                    b.Property<string>("IdExecutor")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id_executor");

                    b.Property<int>("TypeOfService")
                        .HasColumnType("int")
                        .HasColumnName("Type_of_Service");

                    b.HasKey("IdExecutor", "TypeOfService");

                    b.HasIndex(new[] { "TypeOfService" }, "IX_VidRabot_Type_of_Service");

                    b.ToTable("VidRabot", (string)null);
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("IdClient")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdSmeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdSmeta");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.ProvidedService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CostOfM")
                        .HasColumnType("int")
                        .HasColumnName("cost_of_m");

                    b.Property<int?>("CostOfM2")
                        .HasColumnType("int")
                        .HasColumnName("cost_of_m2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Type_of_Service");

                    b.ToTable("ProvidedService", (string)null);
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.Smetum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("CanIdoIt")
                        .HasColumnType("bit")
                        .HasColumnName("canIdoIt");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("FeedbackText")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("feedback_text");

                    b.Property<int?>("GeneralBudget")
                        .HasColumnType("int")
                        .HasColumnName("general_budget");

                    b.Property<int?>("IdClient")
                        .HasMaxLength(450)
                        .HasColumnType("int")
                        .HasColumnName("Id_executor");

                    b.Property<bool?>("IsItFinished")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TimeOrder")
                        .HasColumnType("datetime")
                        .HasColumnName("time_order");

                    b.Property<int?>("VidRabotId_executor")
                        .HasColumnType("int");

                    b.Property<int?>("VidRabotType_of_Service")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VidRabotId_executor", "VidRabotType_of_Service");

                    b.ToTable("Smeta");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("e_mail")
                        .HasAnnotation("Relational:JsonPropertyName", "user_email");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("KolvoZakazov")
                        .HasColumnType("int")
                        .HasColumnName("kolvoZakazov");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<double?>("Rating")
                        .HasColumnType("float")
                        .HasColumnName("rating");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surname");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("telephone_number");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserLogin")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("VidRabotId_executor")
                        .HasColumnType("int");

                    b.Property<int?>("VidRabotType_of_Service")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("VidRabotId_executor", "VidRabotType_of_Service");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex1")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.VidRabot", b =>
                {
                    b.Property<int>("Id_executor")
                        .HasColumnType("int");

                    b.Property<int>("Type_of_Service")
                        .HasColumnType("int");

                    b.Property<string>("ExecutorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id_executor", "Type_of_Service");

                    b.HasIndex("ExecutorId");

                    b.ToTable("VidRabots");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmetaProvidedService", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.ProvidedService", null)
                        .WithMany()
                        .HasForeignKey("IdProvidedService")
                        .IsRequired()
                        .HasConstraintName("FK_SmetaProvidedService_ProvidedService");

                    b.HasOne("WebSheff.ApplicationCore.DomModels.Smetum", null)
                        .WithMany()
                        .HasForeignKey("IdSmeta")
                        .IsRequired()
                        .HasConstraintName("FK_SmetaOrder_Smeta");
                });

            modelBuilder.Entity("VidRabot", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", null)
                        .WithMany()
                        .HasForeignKey("IdExecutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VidRabot_User1");

                    b.HasOne("WebSheff.ApplicationCore.DomModels.ProvidedService", null)
                        .WithMany()
                        .HasForeignKey("TypeOfService")
                        .IsRequired()
                        .HasConstraintName("FK_VidRabot_ProvidedService");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.Order", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", "IdClientNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdClient")
                        .IsRequired()
                        .HasConstraintName("FK_Order_User");

                    b.HasOne("WebSheff.ApplicationCore.DomModels.Smetum", "IdSmetaNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdSmeta")
                        .IsRequired()
                        .HasConstraintName("FK_Order_Smeta");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdSmetaNavigation");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.Smetum", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.VidRabot", null)
                        .WithMany("IdSmeta")
                        .HasForeignKey("VidRabotId_executor", "VidRabotType_of_Service");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.User", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.VidRabot", null)
                        .WithMany("IdExecutors")
                        .HasForeignKey("VidRabotId_executor", "VidRabotType_of_Service");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.VidRabot", b =>
                {
                    b.HasOne("WebSheff.ApplicationCore.DomModels.User", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.Smetum", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebSheff.ApplicationCore.DomModels.VidRabot", b =>
                {
                    b.Navigation("IdExecutors");

                    b.Navigation("IdSmeta");
                });
#pragma warning restore 612, 618
        }
    }
}
