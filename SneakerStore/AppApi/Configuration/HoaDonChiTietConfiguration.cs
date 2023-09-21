using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppApi.Configuration
{
    public class HoaDonChiTietConfiguration :IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(c =>new {c.IDSanPham,c.IDHoaDon});
            builder.HasOne(c => c.SanPham).WithMany().HasForeignKey(c => c.IDSanPham);
            builder.HasOne(c => c.HoaDon).WithMany().HasForeignKey(c => c.IDHoaDon);

        }
    }
}
