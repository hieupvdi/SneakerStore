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
    public class HoaDonChiTietConfiguration :IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.CTSanPham).WithMany().HasForeignKey(c => c.IdCTSP);
            builder.HasOne(c => c.HoaDon).WithMany().HasForeignKey(c => c.IdHD);

            //builder.HasKey(c =>new {c.IdCTSP, c.IdHD });
            //builder.HasOne(c => c.CTSanPham).WithMany().HasForeignKey(c => c.IdCTSP);
            //builder.HasOne(c => c.HoaDon).WithMany().HasForeignKey(c => c.IdHD);

        }
    }
}
