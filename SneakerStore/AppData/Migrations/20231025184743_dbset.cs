using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeGiays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeGiays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMaGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhamTram = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KichCos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichCos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoaiSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMauSac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucThanhToans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucThanhToans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieuKien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoTienGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayApDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    SoDiem = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    ChucVuId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ChucVus_ChucVuId1",
                        column: x => x.ChucVuId1,
                        principalTable: "ChucVus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_ChucVus_IdCV",
                        column: x => x.IdCV,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTSanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gianhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Giaban = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NhaSanXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKichCo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLoaiSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDeGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeGiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GiamGiaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KichCoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoaiSanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MauSacId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTSanPham_DeGiays_DeGiayId",
                        column: x => x.DeGiayId,
                        principalTable: "DeGiays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CTSanPham_DeGiays_IdDeGiay",
                        column: x => x.IdDeGiay,
                        principalTable: "DeGiays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPham_GiamGias_GiamGiaId1",
                        column: x => x.GiamGiaId1,
                        principalTable: "GiamGias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CTSanPham_GiamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "GiamGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPham_KichCos_IdKichCo",
                        column: x => x.IdKichCo,
                        principalTable: "KichCos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPham_KichCos_KichCoId",
                        column: x => x.KichCoId,
                        principalTable: "KichCos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CTSanPham_LoaiSanPhams_IdLoaiSanPham",
                        column: x => x.IdLoaiSanPham,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPham_LoaiSanPhams_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CTSanPham_MauSacs_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPham_MauSacs_MauSacId",
                        column: x => x.MauSacId,
                        principalTable: "MauSacs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CTSanPham_SanPham_IdSP",
                        column: x => x.IdSP,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPham_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_GioHangs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaHD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayShip = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDiemSD = table.Column<int>(type: "int", nullable: false),
                    TienShip = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_Vouchers_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_Vouchers_VoucherId1",
                        column: x => x.VoucherId1,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnhSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URlAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    CTSanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnhSanPhams_CTSanPham_CTSanPhamId",
                        column: x => x.CTSanPhamId,
                        principalTable: "CTSanPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnhSanPhams_CTSanPham_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CTSanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GioHangIdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_CTSanPham_CTSanPhamId",
                        column: x => x.CTSanPhamId,
                        principalTable: "CTSanPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_CTSanPham_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_GioHangIdUser",
                        column: x => x.GioHangIdUser,
                        principalTable: "GioHangs",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_IDUser",
                        column: x => x.IDUser,
                        principalTable: "GioHangs",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CTSanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HoaDonId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_CTSanPham_CTSanPhamId",
                        column: x => x.CTSanPhamId,
                        principalTable: "CTSanPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_CTSanPham_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_HoaDonId1",
                        column: x => x.HoaDonId1,
                        principalTable: "HoaDons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_IdHD",
                        column: x => x.IdHD,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucThanhToanCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPTTT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    PhuongThucThanhToanId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucThanhToanCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhuongThucThanhToanCTs_HoaDons_IdHD",
                        column: x => x.IdHD,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhuongThucThanhToanCTs_PhuongThucThanhToans_IdPTTT",
                        column: x => x.IdPTTT,
                        principalTable: "PhuongThucThanhToans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhuongThucThanhToanCTs_PhuongThucThanhToans_PhuongThucThanhToanId1",
                        column: x => x.PhuongThucThanhToanId1,
                        principalTable: "PhuongThucThanhToans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_CTSanPhamId",
                table: "AnhSanPhams",
                column: "CTSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_IdCTSP",
                table: "AnhSanPhams",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_DeGiayId",
                table: "CTSanPham",
                column: "DeGiayId");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_GiamGiaId1",
                table: "CTSanPham",
                column: "GiamGiaId1");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_IdDeGiay",
                table: "CTSanPham",
                column: "IdDeGiay");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_IdGiamGia",
                table: "CTSanPham",
                column: "IdGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_IdKichCo",
                table: "CTSanPham",
                column: "IdKichCo");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_IdLoaiSanPham",
                table: "CTSanPham",
                column: "IdLoaiSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_IdMauSac",
                table: "CTSanPham",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_IdSP",
                table: "CTSanPham",
                column: "IdSP");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_KichCoId",
                table: "CTSanPham",
                column: "KichCoId");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_LoaiSanPhamId",
                table: "CTSanPham",
                column: "LoaiSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_MauSacId",
                table: "CTSanPham",
                column: "MauSacId");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPham_SanPhamId",
                table: "CTSanPham",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_CTSanPhamId",
                table: "GioHangChiTiets",
                column: "CTSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_GioHangIdUser",
                table: "GioHangChiTiets",
                column: "GioHangIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdCTSP",
                table: "GioHangChiTiets",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IDUser",
                table: "GioHangChiTiets",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_CTSanPhamId",
                table: "HoaDonChiTiets",
                column: "CTSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_HoaDonId1",
                table: "HoaDonChiTiets",
                column: "HoaDonId1");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdCTSP",
                table: "HoaDonChiTiets",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdHD",
                table: "HoaDonChiTiets",
                column: "IdHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdUser",
                table: "HoaDons",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdVoucher",
                table: "HoaDons",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_UserId",
                table: "HoaDons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_VoucherId1",
                table: "HoaDons",
                column: "VoucherId1");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucThanhToanCTs_IdHD",
                table: "PhuongThucThanhToanCTs",
                column: "IdHD");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucThanhToanCTs_IdPTTT",
                table: "PhuongThucThanhToanCTs",
                column: "IdPTTT");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucThanhToanCTs_PhuongThucThanhToanId1",
                table: "PhuongThucThanhToanCTs",
                column: "PhuongThucThanhToanId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChucVuId1",
                table: "Users",
                column: "ChucVuId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdCV",
                table: "Users",
                column: "IdCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhSanPhams");

            migrationBuilder.DropTable(
                name: "GioHangChiTiets");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToanCTs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "CTSanPham");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToans");

            migrationBuilder.DropTable(
                name: "DeGiays");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "KichCos");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "ChucVus");
        }
    }
}
