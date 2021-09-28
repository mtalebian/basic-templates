﻿// <auto-generated />
using Forms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forms.Migrations.Migrations
{
    [DbContext(typeof(FormDbContext))]
    partial class FormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forms.Core.Column", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellStyle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expression")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HiddenInEditor")
                        .HasColumnType("bit");

                    b.Property<bool>("HiddenInTable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPK")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("ToggleOnClick")
                        .HasColumnType("bit");

                    b.Property<string>("ValidValues")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "Id");

                    b.HasIndex("ProjectId", "TableName");

                    b.ToTable("Columns", "tmp");

                    b.HasData(
                        new
                        {
                            ProjectId = "project1",
                            Id = 1,
                            HiddenInEditor = false,
                            HiddenInTable = false,
                            IsPK = true,
                            IsRequired = true,
                            Name = "Id",
                            TableName = "tmp.Projects",
                            Title = "Id",
                            ToggleOnClick = true
                        });
                });

            modelBuilder.Entity("Forms.Core.Group", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProjectId", "Id");

                    b.ToTable("Groups", "tmp");

                    b.HasData(
                        new
                        {
                            ProjectId = "project1",
                            Id = 1,
                            Title = "System Tables"
                        });
                });

            modelBuilder.Entity("Forms.Core.Table", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DeleteSql")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Filterable")
                        .HasColumnType("bit");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("InsertSql")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectSql")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SingularTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sortable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UpdateSql")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "Name");

                    b.HasIndex("ProjectId", "GroupId");

                    b.ToTable("Tables", "tmp");

                    b.HasData(
                        new
                        {
                            ProjectId = "project1",
                            Name = "tmp.Projects",
                            Filterable = true,
                            GroupId = 1,
                            SingularTitle = "Project",
                            Sortable = true,
                            Title = "Projects"
                        });
                });

            modelBuilder.Entity("Forms.Core.Column", b =>
                {
                    b.HasOne("Forms.Core.Table", "Table")
                        .WithMany("Columns")
                        .HasForeignKey("ProjectId", "TableName");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Forms.Core.Table", b =>
                {
                    b.HasOne("Forms.Core.Group", "Group")
                        .WithMany("Tables")
                        .HasForeignKey("ProjectId", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Forms.Core.Group", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Forms.Core.Table", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
