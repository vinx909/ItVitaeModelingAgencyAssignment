﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelingAgency.Data.Service.Infrastructure.Sql;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    [DbContext(typeof(ModelingAgencyContext))]
    partial class ModelingAgencyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
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

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EventTypeId")
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
                });

            modelBuilder.Entity("ModelingAgency.Data.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelId")
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

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Postalcode")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("TelephoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EditOfId");

                    b.ToTable("Models");
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
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelingAgency.Data.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("ModelingAgency.Data.Image", b =>
                {
                    b.HasOne("ModelingAgency.Data.Model", "Model")
                        .WithMany("images")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
