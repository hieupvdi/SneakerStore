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
             new User() { Id = Guid.Parse("e37fa96e-3019-4a16-862f-8fafc6017dfe"),IdCV=Guid.Parse("9cfc528c-bac3-4106-a8d9-745512bb0e3b"),HoTen = "Phạm Văn Hiếu",Url= "images\avta_tr.jpg", Email="hieupham12@gmail.com",TenTaiKhoan="Admin007",MatKhau="1234",SDT=0337019932,GioiTinh=0,TrangThai = 1 }

            );

        }
    }
}
