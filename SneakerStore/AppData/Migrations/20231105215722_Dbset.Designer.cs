﻿// <auto-generated />
using System;
using AppData.SneakerDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppData.Migrations
{
    [DbContext(typeof(SNDbcontext))]
    [Migration("20231105215722_Dbset")]
    partial class Dbset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppData.Models.AnhSanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnhSo")
                        .HasColumnType("int");

                    b.Property<Guid>("IdCTSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("URlAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCTSP");

                    b.ToTable("AnhSanPhams");
                });

            modelBuilder.Entity("AppData.Models.Bog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("UrlAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Bogs");
                });

            modelBuilder.Entity("AppData.Models.ChucVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChucVus");
                });

            modelBuilder.Entity("AppData.Models.CTSanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Giaban")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Gianhap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdDanhMuc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDeGiay")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdGiamGia")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMauSac")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSize")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NhaSanXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDanhMuc");

                    b.HasIndex("IdDeGiay");

                    b.HasIndex("IdGiamGia");

                    b.HasIndex("IdMauSac");

                    b.HasIndex("IdSP");

                    b.HasIndex("IdSize");

                    b.ToTable("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.DanhMuc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DanhMucs");
                });

            modelBuilder.Entity("AppData.Models.DeGiay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeGiays");
                });

            modelBuilder.Entity("AppData.Models.DiaChi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("DiaChis");
                });

            modelBuilder.Entity("AppData.Models.GiamGia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhamTram")
                        .HasColumnType("int");

                    b.Property<string>("TenMaGiamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GiamGias");
                });

            modelBuilder.Entity("AppData.Models.GioHang", b =>
                {
                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdUser");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("AppData.Models.GioHangCT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdCTSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCTSP");

                    b.HasIndex("IdUser");

                    b.ToTable("GioHangCTs");
                });

            modelBuilder.Entity("AppData.Models.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdVoucher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaHD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayShip")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDiemSD")
                        .HasColumnType("int");

                    b.Property<decimal>("TienShip")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("IdVoucher");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("AppData.Models.HoaDonCT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdCTSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCTSP");

                    b.HasIndex("IdHD");

                    b.ToTable("HoaDonCTs");
                });

            modelBuilder.Entity("AppData.Models.MauSac", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenMauSac")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MauSacs");
                });

            modelBuilder.Entity("AppData.Models.PhuongThucThanhToan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhuongThucThanhToans");
                });

            modelBuilder.Entity("AppData.Models.PhuongThucThanhToanCT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPTTT")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SoTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHD");

                    b.HasIndex("IdPTTT");

                    b.ToTable("PhuongThucThanhToanCTs");
                });

            modelBuilder.Entity("AppData.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("AppData.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SizeNumber")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("AppData.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdCV")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDiem")
                        .HasColumnType("int");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("TenTaiKhoan");

                    b.HasIndex("IdCV");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppData.Models.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DieuKien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhanTram")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("SoTienGiam")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("AppData.Models.AnhSanPham", b =>
                {
                    b.HasOne("AppData.Models.CTSanPham", "CTSanPham")
                        .WithMany("AnhSanPhams")
                        .HasForeignKey("IdCTSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CTSanPham");
                });

            modelBuilder.Entity("AppData.Models.Bog", b =>
                {
                    b.HasOne("AppData.Models.User", "User")
                        .WithMany("Bogs")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppData.Models.CTSanPham", b =>
                {
                    b.HasOne("AppData.Models.DanhMuc", "DanhMuc")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdDanhMuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.DeGiay", "DeGiay")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdDeGiay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.GiamGia", "GiamGia")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdGiamGia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.MauSac", "MauSac")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdMauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.SanPham", "SanPham")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.Size", "Size")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");

                    b.Navigation("DeGiay");

                    b.Navigation("GiamGia");

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("AppData.Models.DiaChi", b =>
                {
                    b.HasOne("AppData.Models.User", "User")
                        .WithMany("DiaChis")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppData.Models.GioHang", b =>
                {
                    b.HasOne("AppData.Models.User", "User")
                        .WithOne("GioHang")
                        .HasForeignKey("AppData.Models.GioHang", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppData.Models.GioHangCT", b =>
                {
                    b.HasOne("AppData.Models.CTSanPham", "CTSanPham")
                        .WithMany("GioHangCTs")
                        .HasForeignKey("IdCTSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.GioHang", "GioHang")
                        .WithMany("GioHangCTs")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CTSanPham");

                    b.Navigation("GioHang");
                });

            modelBuilder.Entity("AppData.Models.HoaDon", b =>
                {
                    b.HasOne("AppData.Models.User", "User")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdUser");

                    b.HasOne("AppData.Models.Voucher", "Voucher")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdVoucher");

                    b.Navigation("User");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("AppData.Models.HoaDonCT", b =>
                {
                    b.HasOne("AppData.Models.CTSanPham", "CTSanPham")
                        .WithMany("HoaDonCTs")
                        .HasForeignKey("IdCTSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonCTs")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CTSanPham");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("AppData.Models.PhuongThucThanhToanCT", b =>
                {
                    b.HasOne("AppData.Models.HoaDon", "HoaDon")
                        .WithMany("PhuongThucThanhToanCTs")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.PhuongThucThanhToan", "PhuongThucThanhToan")
                        .WithMany("PhuongThucThanhToanCTs")
                        .HasForeignKey("IdPTTT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("PhuongThucThanhToan");
                });

            modelBuilder.Entity("AppData.Models.User", b =>
                {
                    b.HasOne("AppData.Models.ChucVu", "ChucVu")
                        .WithMany("Users")
                        .HasForeignKey("IdCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("AppData.Models.ChucVu", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AppData.Models.CTSanPham", b =>
                {
                    b.Navigation("AnhSanPhams");

                    b.Navigation("GioHangCTs");

                    b.Navigation("HoaDonCTs");
                });

            modelBuilder.Entity("AppData.Models.DanhMuc", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.DeGiay", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.GiamGia", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.GioHang", b =>
                {
                    b.Navigation("GioHangCTs");
                });

            modelBuilder.Entity("AppData.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonCTs");

                    b.Navigation("PhuongThucThanhToanCTs");
                });

            modelBuilder.Entity("AppData.Models.MauSac", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.PhuongThucThanhToan", b =>
                {
                    b.Navigation("PhuongThucThanhToanCTs");
                });

            modelBuilder.Entity("AppData.Models.SanPham", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.Size", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("AppData.Models.User", b =>
                {
                    b.Navigation("Bogs");

                    b.Navigation("DiaChis");

                    b.Navigation("GioHang");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("AppData.Models.Voucher", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}