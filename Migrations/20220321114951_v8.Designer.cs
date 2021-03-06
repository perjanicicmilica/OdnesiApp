// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Odnesi.Migrations
{
    [DbContext(typeof(OdnesiContext))]
    [Migration("20220321114951_v8")]
    partial class v8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Property<int>("IdKategorije")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdKategorije");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Property<int>("IdProdavnice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdProdavnice");

                    b.ToTable("Prodavnica");
                });

            modelBuilder.Entity("Models.Proizvodi", b =>
                {
                    b.Property<int>("IdProizvoda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Popust")
                        .HasColumnType("int");

                    b.HasKey("IdProizvoda");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.Property<int>("IdSpoja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("KategorijaIdKategorije")
                        .HasColumnType("int");

                    b.Property<int?>("ProdavnicaIdProdavnice")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodIdProizvoda")
                        .HasColumnType("int");

                    b.HasKey("IdSpoja");

                    b.HasIndex("KategorijaIdKategorije");

                    b.HasIndex("ProdavnicaIdProdavnice");

                    b.HasIndex("ProizvodIdProizvoda");

                    b.ToTable("ProdavnicaKategorija");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Kategorija", "Kategorija")
                        .WithMany("ProdavniceProizvodi")
                        .HasForeignKey("KategorijaIdKategorije");

                    b.HasOne("Models.Prodavnica", "Prodavnica")
                        .WithMany("ProdavnicaProizvod")
                        .HasForeignKey("ProdavnicaIdProdavnice");

                    b.HasOne("Models.Proizvodi", "Proizvod")
                        .WithMany("ProizvodProdavnica")
                        .HasForeignKey("ProizvodIdProizvoda");

                    b.Navigation("Kategorija");

                    b.Navigation("Prodavnica");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Navigation("ProdavniceProizvodi");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Navigation("ProdavnicaProizvod");
                });

            modelBuilder.Entity("Models.Proizvodi", b =>
                {
                    b.Navigation("ProizvodProdavnica");
                });
#pragma warning restore 612, 618
        }
    }
}
