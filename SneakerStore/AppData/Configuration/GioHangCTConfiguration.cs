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
    public class GioHangCTConfiguration : IEntityTypeConfiguration<GioHangCT>
    {
        public void Configure(EntityTypeBuilder<GioHangCT> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.CTSanPham).WithMany(p => p.GioHangCTs).HasForeignKey(p => p.IdCTSP);
            builder.HasOne(p => p.GioHang).WithMany(p => p.GioHangCTs).HasForeignKey(p => p.IdUser);

        }
    }
}
