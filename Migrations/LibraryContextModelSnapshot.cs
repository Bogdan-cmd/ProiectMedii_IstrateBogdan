// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMediiMaster_BogdanIstrate.Data;

namespace ProjectMediiMaster_BogdanIstrate.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.AppCustomer", b =>
                {
                    b.Property<int>("AppCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppCustomerId");

                    b.ToTable("AppCustomer");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Factory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("FactoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Guitar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppCustomerId");

                    b.ToTable("Guitar");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.GuitarOrder", b =>
                {
                    b.Property<int>("GuitarOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("GuitarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("GuitarOrderId");

                    b.HasIndex("AppCustomerId");

                    b.HasIndex("GuitarId");

                    b.HasIndex("ReviewId");

                    b.ToTable("GuitarOrder");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.ReleasedGuitar", b =>
                {
                    b.Property<int>("GuitarID")
                        .HasColumnType("int");

                    b.Property<int>("FactoryID")
                        .HasColumnType("int");

                    b.HasKey("GuitarID", "FactoryID");

                    b.HasIndex("FactoryID");

                    b.ToTable("ReleasedGuitar");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("GuitarId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("AppCustomerId");

                    b.HasIndex("GuitarId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Guitar", b =>
                {
                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.AppCustomer", "AppCustomer")
                        .WithMany("Guitars")
                        .HasForeignKey("AppCustomerId");

                    b.Navigation("AppCustomer");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.GuitarOrder", b =>
                {
                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.AppCustomer", "AppCustomer")
                        .WithMany("GuitarOrders")
                        .HasForeignKey("AppCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.Guitar", "Guitar")
                        .WithMany("GuitarOrders")
                        .HasForeignKey("GuitarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.Review", "Review")
                        .WithMany("GuitarOrders")
                        .HasForeignKey("ReviewId");

                    b.Navigation("AppCustomer");

                    b.Navigation("Guitar");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.ReleasedGuitar", b =>
                {
                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.Factory", "Factory")
                        .WithMany("ReleasedGuitars")
                        .HasForeignKey("FactoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.Guitar", "Guitar")
                        .WithMany("ReleasedGuitar")
                        .HasForeignKey("GuitarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");

                    b.Navigation("Guitar");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Review", b =>
                {
                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.AppCustomer", "AppCustomer")
                        .WithMany("Reviews")
                        .HasForeignKey("AppCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMediiMaster_BogdanIstrate.Models.Guitar", "Guitar")
                        .WithMany("Reviews")
                        .HasForeignKey("GuitarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppCustomer");

                    b.Navigation("Guitar");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.AppCustomer", b =>
                {
                    b.Navigation("GuitarOrders");

                    b.Navigation("Guitars");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Factory", b =>
                {
                    b.Navigation("ReleasedGuitars");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Guitar", b =>
                {
                    b.Navigation("GuitarOrders");

                    b.Navigation("ReleasedGuitar");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ProjectMediiMaster_BogdanIstrate.Models.Review", b =>
                {
                    b.Navigation("GuitarOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
