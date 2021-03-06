// <auto-generated />
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
    [Migration("20210615123853_initial")]
    partial class initial
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

            modelBuilder.Entity("ModelingAgency.Data.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ModelingAgency.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ModelingAgency.Data.Client", b =>
                {
                    b.HasBaseType("ModelingAgency.Data.Person");

                    b.Property<bool>("Aproved")
                        .HasColumnType("bit");

                    b.Property<int>("BTWNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EditOfId")
                        .HasColumnType("int");

                    b.Property<int>("KVKNumber")
                        .HasColumnType("int");

                    b.HasIndex("EditOfId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ModelingAgency.Data.Model", b =>
                {
                    b.HasBaseType("ModelingAgency.Data.Person");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<bool>("Aproved")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EMailAdress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EditOfId")
                        .HasColumnType("int");

                    b.Property<int>("TelephoneNumber")
                        .HasColumnType("int");

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
                        .WithMany("Images")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ModelingAgency.Data.Client", b =>
                {
                    b.HasOne("ModelingAgency.Data.Client", "EditOf")
                        .WithMany()
                        .HasForeignKey("EditOfId");

                    b.HasOne("ModelingAgency.Data.Person", null)
                        .WithOne()
                        .HasForeignKey("ModelingAgency.Data.Client", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("EditOf");
                });

            modelBuilder.Entity("ModelingAgency.Data.Model", b =>
                {
                    b.HasOne("ModelingAgency.Data.Model", "EditOf")
                        .WithMany()
                        .HasForeignKey("EditOfId");

                    b.HasOne("ModelingAgency.Data.Person", null)
                        .WithOne()
                        .HasForeignKey("ModelingAgency.Data.Model", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("EditOf");
                });

            modelBuilder.Entity("ModelingAgency.Data.Client", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ModelingAgency.Data.Model", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
