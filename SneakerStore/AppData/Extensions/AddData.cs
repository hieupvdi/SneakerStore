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
