﻿// <auto-generated />
using System;
using Accounts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accounts.Migrations.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    [Migration("20211127105725_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accounts.Core.Application", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Accounts.Core.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId", "RoleId");

                    b.ToTable("Authorizations", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.AzField", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ValidValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesQuery")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("AzFields", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.AzObject", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("AzObjects", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.AzObjectField", b =>
                {
                    b.Property<string>("ObjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FieldId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ObjectId", "FieldId");

                    b.HasIndex("FieldId");

                    b.ToTable("AzObjectFields", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.AzValue", b =>
                {
                    b.Property<int>("Serial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorizationId")
                        .HasColumnType("int");

                    b.Property<string>("FieldId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Serial");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("ObjectId", "FieldId");

                    b.ToTable("AzValues", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.CompositeRole", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProjectId", "Id");

                    b.ToTable("CompositeRoles", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.Menu", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Id")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("OpenInNewTab")
                        .HasColumnType("bit");

                    b.Property<string>("ParentId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ProjectId", "Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProjectId", "ParentId");

                    b.ToTable("Menus", "tmp");

                    b.HasData(
                        new
                        {
                            ProjectId = "project1",
                            Id = "config-grid-builder",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "config",
                            SortOrder = 0,
                            Title = "Grid builder",
                            Url = "/admin/grid-builder"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "config-grids",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "config",
                            SortOrder = 0,
                            Title = "Maintain base tables",
                            Url = "/admin/grids"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "config-grid",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "config",
                            SortOrder = 0,
                            Title = "Maintain table",
                            Url = "/admin/grid"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "config-menu",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "config",
                            SortOrder = 0,
                            Title = "Maintain project menu",
                            Url = "/admin/menu"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "users",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "admin",
                            SortOrder = 0,
                            Title = "Manage Users",
                            Url = "/admin/users"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "roles",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "admin",
                            SortOrder = 0,
                            Title = "Manage Roles",
                            Url = "/admin/roles"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "composite-roles",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OpenInNewTab = false,
                            ParentId = "admin",
                            SortOrder = 0,
                            Title = "Manage Composite Role",
                            Url = "/admin/composite-roles"
                        });
                });

            modelBuilder.Entity("Accounts.Core.MenuFolder", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Id")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ParentId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProjectId", "Id");

                    b.HasIndex("ProjectId", "ParentId");

                    b.ToTable("MenuFolders", "tmp");

                    b.HasData(
                        new
                        {
                            ProjectId = "project1",
                            Id = "config",
                            SortOrder = 0,
                            Title = "Project Configuration"
                        },
                        new
                        {
                            ProjectId = "project1",
                            Id = "admin",
                            SortOrder = 0,
                            Title = "Project Administartion"
                        });
                });

            modelBuilder.Entity("Accounts.Core.Project", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Projects", "tmp");

                    b.HasData(
                        new
                        {
                            Id = "project1",
                            Title = "Project 1"
                        });
                });

            modelBuilder.Entity("Accounts.Core.Role", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProjectId", "Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Roles", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.RoleCompositeRole", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompositeRoleId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProjectId", "RoleId", "CompositeRoleId");

                    b.HasIndex("ProjectId", "CompositeRoleId");

                    b.ToTable("RoleCompositeRoles", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastAccessFailedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("WindowsAuthenticate")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users", "tmp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff19e81a-b002-4f1c-8093-ed6910bf51ba",
                            CreatedAt = new DateTime(2021, 11, 27, 14, 27, 24, 800, DateTimeKind.Local).AddTicks(6393),
                            EmailConfirmed = false,
                            FirstName = "",
                            IsDeleted = false,
                            IsDisabled = false,
                            LastName = "Administrator",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LockoutEnabled = false,
                            PasswordHash = "PABPyu6/prVEQ4QbBrmcATJsjw/1yoli07rNI6EJ764=",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3b314a6a-e82c-44eb-b857-03a867b4144e",
                            UserName = "admin",
                            WindowsAuthenticate = false
                        });
                });

            modelBuilder.Entity("Accounts.Core.UserAgent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Device")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAgents", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.UserCompositeRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CompositeRoleId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId", "ProjectId", "CompositeRoleId");

                    b.HasIndex("ProjectId", "CompositeRoleId");

                    b.ToTable("UserCompositeRoles", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId", "ProjectId", "RoleId");

                    b.HasIndex("ProjectId", "RoleId");

                    b.ToTable("UserRoles", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.UserSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("IPList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastIP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RefreshCount")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RefreshTokenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserAgentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAgentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions", "tmp");
                });

            modelBuilder.Entity("Accounts.Core.Authorization", b =>
                {
                    b.HasOne("Accounts.Core.Role", "Role")
                        .WithMany("Authorizations")
                        .HasForeignKey("ProjectId", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Accounts.Core.AzField", b =>
                {
                    b.HasOne("Accounts.Core.Project", "Project")
                        .WithMany("AzFields")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Accounts.Core.AzObject", b =>
                {
                    b.HasOne("Accounts.Core.Project", "Project")
                        .WithMany("AzObjects")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Accounts.Core.AzObjectField", b =>
                {
                    b.HasOne("Accounts.Core.AzField", "AzField")
                        .WithMany("AzObjectFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.AzObject", "AzObject")
                        .WithMany("AzObjectFields")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AzField");

                    b.Navigation("AzObject");
                });

            modelBuilder.Entity("Accounts.Core.AzValue", b =>
                {
                    b.HasOne("Accounts.Core.Authorization", "Authorization")
                        .WithMany("Values")
                        .HasForeignKey("AuthorizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.AzObjectField", "AzObjectField")
                        .WithMany("Values")
                        .HasForeignKey("ObjectId", "FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authorization");

                    b.Navigation("AzObjectField");
                });

            modelBuilder.Entity("Accounts.Core.Menu", b =>
                {
                    b.HasOne("Accounts.Core.Application", "Application")
                        .WithMany("Menus")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Accounts.Core.Project", "Project")
                        .WithMany("Menus")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.MenuFolder", "Parent")
                        .WithMany("Menus")
                        .HasForeignKey("ProjectId", "ParentId");

                    b.Navigation("Application");

                    b.Navigation("Parent");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Accounts.Core.MenuFolder", b =>
                {
                    b.HasOne("Accounts.Core.Project", "Project")
                        .WithMany("MenuFolders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.MenuFolder", "Parent")
                        .WithMany("SubFolders")
                        .HasForeignKey("ProjectId", "ParentId");

                    b.Navigation("Parent");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Accounts.Core.Role", b =>
                {
                    b.HasOne("Accounts.Core.Application", "Application")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationId");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Accounts.Core.RoleCompositeRole", b =>
                {
                    b.HasOne("Accounts.Core.CompositeRole", "CompositeRole")
                        .WithMany("RoleCompositeRoles")
                        .HasForeignKey("ProjectId", "CompositeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.Role", "Role")
                        .WithMany("RoleCompositeRoles")
                        .HasForeignKey("ProjectId", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompositeRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Accounts.Core.UserCompositeRole", b =>
                {
                    b.HasOne("Accounts.Core.User", "User")
                        .WithMany("UserCompositeRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.CompositeRole", "CompositeRole")
                        .WithMany("UserCompositeRoles")
                        .HasForeignKey("ProjectId", "CompositeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompositeRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accounts.Core.UserRole", b =>
                {
                    b.HasOne("Accounts.Core.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("ProjectId", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Accounts.Core.UserSession", b =>
                {
                    b.HasOne("Accounts.Core.UserAgent", "UserAgent")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserAgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Core.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserAgent");
                });

            modelBuilder.Entity("Accounts.Core.Application", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Accounts.Core.Authorization", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Accounts.Core.AzField", b =>
                {
                    b.Navigation("AzObjectFields");
                });

            modelBuilder.Entity("Accounts.Core.AzObject", b =>
                {
                    b.Navigation("AzObjectFields");
                });

            modelBuilder.Entity("Accounts.Core.AzObjectField", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Accounts.Core.CompositeRole", b =>
                {
                    b.Navigation("RoleCompositeRoles");

                    b.Navigation("UserCompositeRoles");
                });

            modelBuilder.Entity("Accounts.Core.MenuFolder", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("SubFolders");
                });

            modelBuilder.Entity("Accounts.Core.Project", b =>
                {
                    b.Navigation("AzFields");

                    b.Navigation("AzObjects");

                    b.Navigation("MenuFolders");

                    b.Navigation("Menus");
                });

            modelBuilder.Entity("Accounts.Core.Role", b =>
                {
                    b.Navigation("Authorizations");

                    b.Navigation("RoleCompositeRoles");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Accounts.Core.User", b =>
                {
                    b.Navigation("UserCompositeRoles");

                    b.Navigation("UserRoles");

                    b.Navigation("UserSessions");
                });

            modelBuilder.Entity("Accounts.Core.UserAgent", b =>
                {
                    b.Navigation("UserSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
