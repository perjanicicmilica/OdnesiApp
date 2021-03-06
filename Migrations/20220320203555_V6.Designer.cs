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
    [Migration("20220320203555_V6")]
    partial class V6
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

            modelBuilder.Entity("Models.Narudzbenica", b =>
                {
                    b.Property<int>("IdNarudzbenice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdresaKupca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DatumNarudzbenice")
                        .HasColumnType("int");

                    b.Property<string>("ImeiPrezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Racun")
                        .HasColumnType("int");

                    b.HasKey("IdNarudzbenice");

                    b.ToTable("Narudzbenica");
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

                    b.Property<int?>("NarudzbenicaIdNarudzbenice")
                        .HasColumnType("int");

                    b.Property<int?>("ProdavnicaIdProdavnice")
                        .HasColumnType("int");

                    b.HasKey("IdSpoja");

                    b.HasIndex("KategorijaIdKategorije");

                    b.HasIndex("NarudzbenicaIdNarudzbenice");

                    b.HasIndex("ProdavnicaIdProdavnice");

                    b.ToTable("ProdavnicaKategorija");
                });

            modelBuilder.Entity("Models.SpojProizvoda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("KategorijaIdKategorije")
                        .HasColumnType("int");

                    b.Property<int?>("NarudzbenicaIdNarudzbenice")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodiIdProizvoda")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KategorijaIdKategorije");

                    b.HasIndex("NarudzbenicaIdNarudzbenice");

                    b.HasIndex("ProizvodiIdProizvoda");

                    b.ToTable("ProizvodiKategorija");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Kategorija", "Kategorija")
                        .WithMany("KategorijaProdavnica")
                        .HasForeignKey("KategorijaIdKategorije");

                    b.HasOne("Models.Narudzbenica", "Narudzbenica")
                        .WithMany("NarudzbenicaProdavnica")
                        .HasForeignKey("NarudzbenicaIdNarudzbenice");

                    b.HasOne("Models.Prodavnica", "Prodavnica")
                        .WithMany("ProdavnicaKategorija")
                        .HasForeignKey("ProdavnicaIdProdavnice");

                    b.Navigation("Kategorija");

                    b.Navigation("Narudzbenica");

                    b.Navigation("Prodavnica");
                });

            modelBuilder.Entity("Models.SpojProizvoda", b =>
                {
                    b.HasOne("Models.Kategorija", "Kategorija")
                        .WithMany("KategorijaProizvoda")
                        .HasForeignKey("KategorijaIdKategorije");

                    b.HasOne("Models.Narudzbenica", "Narudzbenica")
                        .WithMany("NarudzbenicaProizvoda")
                        .HasForeignKey("NarudzbenicaIdNarudzbenice");

                    b.HasOne("Models.Proizvodi", "Proizvodi")
                        .WithMany("ProizvodKategorija")
                        .HasForeignKey("ProizvodiIdProizvoda");

                    b.Navigation("Kategorija");

                    b.Navigation("Narudzbenica");

                    b.Navigation("Proizvodi");
                });

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Navigation("KategorijaProdavnica");

                    b.Navigation("KategorijaProizvoda");
                });

            modelBuilder.Entity("Models.Narudzbenica", b =>
                {
                    b.Navigation("NarudzbenicaProdavnica");

                    b.Navigation("NarudzbenicaProizvoda");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Navigation("ProdavnicaKategorija");
                });

            modelBuilder.Entity("Models.Proizvodi", b =>
                {
                    b.Navigation("ProizvodKategorija");
                });
#pragma warning restore 612, 618
        }
    }
}
