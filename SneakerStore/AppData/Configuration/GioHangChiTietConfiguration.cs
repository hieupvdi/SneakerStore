using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Configuration
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.HasKey(c => c.ID);

            builder.HasOne(p => p.CTSanPham).WithMany(p => p.GioHangChiTiets).HasForeignKey(p => p.IdCTSP);
            builder.HasOne(p => p.GioHang).WithMany(p => p.GioHangChiTiets).HasForeignKey(p => p.IDUser);

        }
    }
}
