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
                name: "DanhMucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Id);
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
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeNumber = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieuKien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTram = table.Column<int>(type: "int", nullable: false),
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
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_TenTaiKhoan", x => x.TenTaiKhoan);
                    table.ForeignKey(
                        name: "FK_Users_ChucVus_IdCV",
                        column: x => x.IdCV,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gianhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Giaban = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NhaSanXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDeGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_DanhMucs_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_DeGiays_IdDeGiay",
                        column: x => x.IdDeGiay,
                        principalTable: "DeGiays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_GiamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "GiamGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_MauSacs_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_SanPhams_IdSP",
                        column: x => x.IdSP,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_Sizes_IdSize",
                        column: x => x.IdSize,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaChis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaChis_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    PTThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TienShip = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_HoaDons_Vouchers_IdVoucher",
                        column: x => x.IdVoucher,
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
                    AnhSo = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnhSanPhams_CTSanPhams_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangCTs_CTSanPhams_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangCTs_GioHangs_IdUser",
                        column: x => x.IdUser,
                        principalTable: "GioHangs",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCTSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonCTs_CTSanPhams_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonCTs_HoaDons_IdHD",
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
                    TrangThai = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "ChucVus",
                columns: new[] { "Id", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("9cfc528c-bac3-4106-a8d9-745512bb0e3b"), "Admin", 1 },
                    { new Guid("e26fa84e-3019-4a14-862f-9fafc6014dfe"), "Người Dùng", 1 }
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "Id", "Ten", "TrangThai" },
                values: new object[] { new Guid("c0cf812b-ae5c-4843-b2d8-4221428bdaa2"), "Giày thể thao", 1 });

            migrationBuilder.InsertData(
                table: "DeGiays",
                columns: new[] { "Id", "Name", "TrangThai" },
                values: new object[] { new Guid("740da37d-5d41-4bb2-8596-f0db0c000395"), "Đế cao su", 1 });

            migrationBuilder.InsertData(
                table: "GiamGias",
                columns: new[] { "Id", "MoTa", "NgayBatDau", "NgayKetThuc", "PhamTram", "TenMaGiamGia", "TrangThai" },
                values: new object[] { new Guid("af96daff-10c2-4433-9650-b01c4dd9a0b8"), "Nhân ngày shop mới mở bán", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), 5, "Tri ân khách hàng", 1 });

            migrationBuilder.InsertData(
                table: "MauSacs",
                columns: new[] { "Id", "TenMauSac", "TrangThai" },
                values: new object[] { new Guid("d5695ca6-672e-47f0-b00f-2d8bf646fd07"), "beige", 1 });

            migrationBuilder.InsertData(
                table: "PhuongThucThanhToans",
                columns: new[] { "Id", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("a29e87a9-921c-4964-9932-b4d038244a88"), "Thanh Toán Khi Nhận Hàng", 1 },
                    { new Guid("eb546cee-a51f-413b-ae43-456623900bd4"), "Thanh Toán VNPAY", 1 }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "TenSP", "TrangThai" },
                values: new object[] { new Guid("1b1ea42e-e45a-4536-b3bb-8819ccf97c25"), "Giày Thời Trang Unisex Converse Chuck Taylor All Star", 1 });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "SizeNumber", "TrangThai" },
                values: new object[] { new Guid("7098f9a9-d98e-48ef-81d2-5519542889c9"), 40, 1 });

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "Id", "DieuKien", "MoTa", "NgayBatDau", "NgayKetThuc", "PhanTram", "SoLuong", "Ten", "TrangThai" },
                values: new object[] { new Guid("58d680d9-696f-4de5-93f5-5024b77efec7"), 50000m, "Shop mới khai trương", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 100, "khai trương", 1 });

            migrationBuilder.InsertData(
                table: "CTSanPhams",
                columns: new[] { "Id", "ChatLieu", "Giaban", "Gianhap", "IdDanhMuc", "IdDeGiay", "IdGiamGia", "IdMauSac", "IdSP", "IdSize", "MoTa", "NhaSanXuat", "SoLuongTon", "TrangThai" },
                values: new object[] { new Guid("b24acc5b-1f48-4aed-a28b-a28a46afeb3f"), "Vãi tổng hợp", 550000m, 600000m, new Guid("c0cf812b-ae5c-4843-b2d8-4221428bdaa2"), new Guid("740da37d-5d41-4bb2-8596-f0db0c000395"), new Guid("af96daff-10c2-4433-9650-b01c4dd9a0b8"), new Guid("d5695ca6-672e-47f0-b00f-2d8bf646fd07"), new Guid("1b1ea42e-e45a-4536-b3bb-8819ccf97c25"), new Guid("7098f9a9-d98e-48ef-81d2-5519542889c9"), "hàng mới 100%", "made in China ", 30, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GioiTinh", "HoTen", "IdCV", "MatKhau", "SDT", "TenTaiKhoan", "TrangThai", "Url" },
                values: new object[] { new Guid("e37fa96e-3019-4a16-862f-8fafc6017dfe"), "hieupvph27565@fpt.edu.vn", 0, "Phạm Văn Hiếu", new Guid("9cfc528c-bac3-4106-a8d9-745512bb0e3b"), "1234", "0337019932", "Admin007", 1, "/images/anh-anime-chibi-2.jpg" });

            migrationBuilder.InsertData(
                table: "AnhSanPhams",
                columns: new[] { "Id", "AnhSo", "IdCTSP", "TrangThai", "URlAnh" },
                values: new object[] { new Guid("ad88a222-3be0-4780-aba9-6097eb0735ff"), 1, new Guid("b24acc5b-1f48-4aed-a28b-a28a46afeb3f"), 1, "/images/Converse9.jpeg" });

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_IdCTSP",
                table: "AnhSanPhams",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_IdUser",
                table: "Blogs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdDanhMuc",
                table: "CTSanPhams",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdDeGiay",
                table: "CTSanPhams",
                column: "IdDeGiay");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdGiamGia",
                table: "CTSanPhams",
                column: "IdGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdMauSac",
                table: "CTSanPhams",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdSize",
                table: "CTSanPhams",
                column: "IdSize");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdSP",
                table: "CTSanPhams",
                column: "IdSP");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChis_IdUser",
                table: "DiaChis",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCTs_IdCTSP",
                table: "GioHangCTs",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCTs_IdUser",
                table: "GioHangCTs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCTs_IdCTSP",
                table: "HoaDonCTs",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCTs_IdHD",
                table: "HoaDonCTs",
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
                name: "IX_PhuongThucThanhToanCTs_IdHD",
                table: "PhuongThucThanhToanCTs",
                column: "IdHD");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucThanhToanCTs_IdPTTT",
                table: "PhuongThucThanhToanCTs",
                column: "IdPTTT");

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
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "DiaChis");

            migrationBuilder.DropTable(
                name: "GioHangCTs");

            migrationBuilder.DropTable(
                name: "HoaDonCTs");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToanCTs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "CTSanPhams");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToans");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "DeGiays");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "ChucVus");
        }
    }
}
