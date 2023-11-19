using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Extensions
{
    public static  class AddData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AnhSanPham>().HasData(
            new AnhSanPham() { Id = Guid.Parse("ad88a222-3be0-4780-aba9-6097eb0735ff"), IdCTSP = Guid.Parse("b24acc5b-1f48-4aed-a28b-a28a46afeb3f"), URlAnh = "/images/Converse9.jpeg", AnhSo = 1, TrangThai = 1 }
            );

            modelBuilder.Entity<SanPham>().HasData(
          new SanPham() { Id = Guid.Parse("1b1ea42e-e45a-4536-b3bb-8819ccf97c25"),TenSP = "Giày Thời Trang Unisex Converse Chuck Taylor All Star", TrangThai = 1 }
          );


            modelBuilder.Entity<DanhMuc>().HasData(
          new DanhMuc() { Id = Guid.Parse("c0cf812b-ae5c-4843-b2d8-4221428bdaa2"), Ten = "Giày thể thao", TrangThai = 1 }
          );

            modelBuilder.Entity<DeGiay>().HasData(
               new DeGiay() { Id = Guid.Parse("740da37d-5d41-4bb2-8596-f0db0c000395"), Name = "Đế cao su", TrangThai = 1 }
               );

            modelBuilder.Entity<MauSac>().HasData(
            new MauSac() { Id = Guid.Parse("d5695ca6-672e-47f0-b00f-2d8bf646fd07"), TenMauSac = "beige", TrangThai = 1 }
            );

            modelBuilder.Entity<Size>().HasData(
        new Size() { Id = Guid.Parse("7098f9a9-d98e-48ef-81d2-5519542889c9"), SizeNumber = 40, TrangThai = 1 }
        );
            modelBuilder.Entity<GiamGia>().HasData(
        new GiamGia() { Id = Guid.Parse("af96daff-10c2-4433-9650-b01c4dd9a0b8"), TenMaGiamGia = "Tri ân khách hàng",NgayBatDau=new DateTime(2023 - 11 - 17),NgayKetThuc=new DateTime(2024 - 11 - 17),PhamTram=5,MoTa="Nhân ngày shop mới mở bán",TrangThai = 1 }
        );
            modelBuilder.Entity<CTSanPham>().HasData(
            new CTSanPham() { Id = Guid.Parse("b24acc5b-1f48-4aed-a28b-a28a46afeb3f"), MoTa = "hàng mới 100%",Gianhap= 600000,Giaban=550000,ChatLieu="Vãi tổng hợp" ,SoLuongTon=30,
              NhaSanXuat= "made in China ",
              IdSP=Guid.Parse("1b1ea42e-e45a-4536-b3bb-8819ccf97c25"),
              IdSize = Guid.Parse("7098f9a9-d98e-48ef-81d2-5519542889c9"),
              IdMauSac = Guid.Parse("d5695ca6-672e-47f0-b00f-2d8bf646fd07"),
              IdDanhMuc = Guid.Parse("c0cf812b-ae5c-4843-b2d8-4221428bdaa2"),
              IdDeGiay = Guid.Parse("740da37d-5d41-4bb2-8596-f0db0c000395"),
              IdGiamGia = Guid.Parse("af96daff-10c2-4433-9650-b01c4dd9a0b8"),         
              TrangThai = 1 }
          );


            modelBuilder.Entity<Voucher>().HasData(
             new Voucher() { Id = Guid.Parse("58d680d9-696f-4de5-93f5-5024b77efec7"), Ten = "khai trương",DieuKien=50000,NgayBatDau=new DateTime(),NgayKetThuc=new DateTime(),PhanTram=5,SoLuong=100,MoTa= "Shop mới khai trương", TrangThai = 1 }
            );


            modelBuilder.Entity<ChucVu>().HasData(
             new ChucVu() { Id = Guid.Parse("e26fa84e-3019-4a14-862f-9fafc6014dfe"), Ten = "Người Dùng" ,TrangThai=1},
             new ChucVu() { Id = Guid.Parse("9cfc528c-bac3-4106-a8d9-745512bb0e3b"), Ten = "Admin" ,TrangThai=1}
             );
            modelBuilder.Entity<User>().HasData(
             new User() { Id = Guid.Parse("e37fa96e-3019-4a16-862f-8fafc6017dfe"),IdCV=Guid.Parse("9cfc528c-bac3-4106-a8d9-745512bb0e3b"),HoTen = "Phạm Văn Hiếu",Url= "/images/anh-anime-chibi-2.jpg", Email="hieupvph27565@fpt.edu.vn",TenTaiKhoan="Admin007",MatKhau="1234",SDT= "0337019932", GioiTinh=0,TrangThai = 1 }

            );


            modelBuilder.Entity<PhuongThucThanhToan>().HasData(
             new PhuongThucThanhToan() { Id = Guid.Parse("a29e87a9-921c-4964-9932-b4d038244a88"), Ten = "Thanh Toán Khi Nhận Hàng", TrangThai = 1 },
             new PhuongThucThanhToan() { Id = Guid.Parse("eb546cee-a51f-413b-ae43-456623900bd4"), Ten = "Thanh Toán VNPAY", TrangThai = 1 }

            );

    
        }
    }
}
