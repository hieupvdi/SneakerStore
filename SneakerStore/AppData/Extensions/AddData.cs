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
             new ChucVu() { Id = Guid.Parse("e26fa84e-3019-4a14-862f-9fafc6014dfe"), Ten = "Người Dùng" ,TrangThai=1}

             );
 

        }
    }
}
