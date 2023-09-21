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
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasOne(c => c.SanPham).WithMany().HasForeignKey(c => c.IDSanPham);
            builder.HasOne(c => c.GioHang).WithMany().HasForeignKey(c => c.IDUser);
        }
    }
}
