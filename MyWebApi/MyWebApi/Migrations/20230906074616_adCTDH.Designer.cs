﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApi.Data;

#nullable disable

namespace MyWebApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230906074616_adCTDH")]
    partial class adCTDH
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWebApi.Data.DonHang", b =>
                {
                    b.Property<Guid>("MaDH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("NgGiao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiNhanHang")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TinhTrangDonHang")
                        .HasColumnType("int");

                    b.HasKey("MaDH");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Data.DonHangChiTiet", b =>
                {
                    b.Property<Guid>("MaHH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaDH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaHH", "MaDH");

                    b.HasIndex("MaDH");

                    b.ToTable("ChiTietDonHang", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Data.HangHoa", b =>
                {
                    b.Property<Guid>("MaHH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaHH");

                    b.HasIndex("MaLoai");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("MyWebApi.Data.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("MyWebApi.Data.DonHangChiTiet", b =>
                {
                    b.HasOne("MyWebApi.Data.DonHang", "DonHang")
                        .WithMany("donHangChiTiets")
                        .HasForeignKey("MaDH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DONHANGCT_DonHang");

                    b.HasOne("MyWebApi.Data.HangHoa", "HangHoa")
                        .WithMany("donHangChiTiets")
                        .HasForeignKey("MaHH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DONHANGCT_HangHoa");

                    b.Navigation("DonHang");

                    b.Navigation("HangHoa");
                });

            modelBuilder.Entity("MyWebApi.Data.HangHoa", b =>
                {
                    b.HasOne("MyWebApi.Data.Loai", "Loai")
                        .WithMany("HangHoas")
                        .HasForeignKey("MaLoai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("MyWebApi.Data.DonHang", b =>
                {
                    b.Navigation("donHangChiTiets");
                });

            modelBuilder.Entity("MyWebApi.Data.HangHoa", b =>
                {
                    b.Navigation("donHangChiTiets");
                });

            modelBuilder.Entity("MyWebApi.Data.Loai", b =>
                {
                    b.Navigation("HangHoas");
                });
#pragma warning restore 612, 618
        }
    }
}
