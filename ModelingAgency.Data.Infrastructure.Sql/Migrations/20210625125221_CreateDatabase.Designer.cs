﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelingAgency.Data.Service.Infrastructure.Sql;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    [DbContext(typeof(ModelingAgencyContext))]
    [Migration("20210625125221_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventModel", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("ModelsId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "ModelsId");

                    b.HasIndex("ModelsId");

                    b.ToTable("EventModel");
                });

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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ModelingAgency.Data.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressNumber")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<bool>("Aproved")
                        .HasColumnType("bit");

                    b.Property<int>("BTWNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("EditOfId")
                        .HasColumnType("int");

                    b.Property<int>("KVKNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Postalcode")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("EditOfId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressNumber = 45,
                            Aproved = false,
                            BTWNumber = 12345678,
                            City = "Amsterdam",
                            KVKNumber = 345678912,
                            Name = "Henk",
                            Postalcode = "1234 GH"
                        },
                        new
                        {
                            Id = 2,
                            AddressNumber = 15,
                            Aproved = false,
                            BTWNumber = 45678123,
                            City = "Rotterdam",
                            KVKNumber = 67891234,
                            Name = "Jaap",
                            Postalcode = "3456 ER"
                        },
                        new
                        {
                            Id = 3,
                            AddressNumber = 69,
                            Aproved = false,
                            BTWNumber = 89123456,
                            City = "Groningen",
                            KVKNumber = 14235867,
                            Name = "Andre",
                            Postalcode = "4567 YU"
                        });
                });

            modelBuilder.Entity("ModelingAgency.Data.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressNumber")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Postalcode")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressNumber = 12,
                            Description = "Show met auto's",
                            Duration = 3,
                            Name = "Auto show",
                            Postalcode = "3568 GG",
                            StartTime = new DateTime(2021, 6, 27, 14, 52, 20, 604, DateTimeKind.Local).AddTicks(5141)
                        },
                        new
                        {
                            Id = 2,
                            AddressNumber = 3,
                            Description = "Evenement rondom anime",
                            Duration = 3,
                            Name = "Anime con",
                            Postalcode = "4201 BR",
                            StartTime = new DateTime(2021, 6, 30, 14, 52, 20, 607, DateTimeKind.Local).AddTicks(5086)
                        },
                        new
                        {
                            Id = 3,
                            AddressNumber = 7,
                            Description = "Show met verzamel items",
                            Duration = 1,
                            Name = "Verzamelbeurs",
                            Postalcode = "6734 TY",
                            StartTime = new DateTime(2021, 7, 2, 14, 52, 20, 607, DateTimeKind.Local).AddTicks(5116)
                        });
                });

            modelBuilder.Entity("ModelingAgency.Data.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Evenement waarbij nieuwe producten worden gepresenteerd",
                            Name = "Beurs"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Evenement waarbij entertainment rondom een bepaald onderwerp centraal staat",
                            Name = "Conventie"
                        });
                });

            modelBuilder.Entity("ModelingAgency.Data.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ModelingAgency.Data.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressNumber")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<bool>("Aproved")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ClothingSize")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EMailAdress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EditOfId")
                        .HasColumnType("int");

                    b.Property<string>("EyeColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Postalcode")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("TelephoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EditOfId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressNumber = 12,
                            Age = (short)22,
                            Aproved = false,
                            City = "Amsterdam",
                            ClothingSize = 38,
                            Description = "Veel energie",
                            EMailAdress = "LotteKraamer@gmail.com",
                            EyeColor = "Blauw-groen",
                            HairColor = "Blond",
                            Length = 178,
                            Name = "Lotte",
                            Postalcode = "4623 GH",
                            TelephoneNumber = 612345678
                        },
                        new
                        {
                            Id = 2,
                            AddressNumber = 8,
                            Age = (short)24,
                            Aproved = false,
                            City = "Groningen",
                            ClothingSize = 40,
                            Description = "Rustig",
                            EMailAdress = "AnneVanBeekeren@gmail.com",
                            EyeColor = "Blauw",
                            HairColor = "Licht-Bruin",
                            Length = 176,
                            Name = "Anne",
                            Postalcode = "7856 TH",
                            TelephoneNumber = 612341234
                        },
                        new
                        {
                            Id = 3,
                            AddressNumber = 3,
                            Age = (short)21,
                            Aproved = false,
                            City = "Amersfoort",
                            ClothingSize = 36,
                            Description = "Ingetogen",
                            EMailAdress = "EmmaVanZuiden@gmail.com",
                            EyeColor = "Bruin",
                            HairColor = "Zwart",
                            Length = 174,
                            Name = "Emma",
                            Postalcode = "5674 UH",
                            TelephoneNumber = 612344567
                        });
                });

            modelBuilder.Entity("EventModel", b =>
                {
                    b.HasOne("ModelingAgency.Data.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelingAgency.Data.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModelingAgency.Data.Client", b =>
                {
                    b.HasOne("ModelingAgency.Data.Client", "EditOf")
                        .WithMany()
                        .HasForeignKey("EditOfId");

                    b.Navigation("EditOf");
                });

            modelBuilder.Entity("ModelingAgency.Data.Event", b =>
                {
                    b.HasOne("ModelingAgency.Data.Client", "Client")
                        .WithMany("Events")
                        .HasForeignKey("ClientId");

                    b.HasOne("ModelingAgency.Data.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.Navigation("Client");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("ModelingAgency.Data.Image", b =>
                {
                    b.HasOne("ModelingAgency.Data.Model", "Model")
                        .WithMany("images")
                        .HasForeignKey("ModelId");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ModelingAgency.Data.Model", b =>
                {
                    b.HasOne("ModelingAgency.Data.Model", "EditOf")
                        .WithMany()
                        .HasForeignKey("EditOfId");

                    b.Navigation("EditOf");
                });

            modelBuilder.Entity("ModelingAgency.Data.Client", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ModelingAgency.Data.Model", b =>
                {
                    b.Navigation("images");
                });
#pragma warning restore 612, 618
        }
    }
}
