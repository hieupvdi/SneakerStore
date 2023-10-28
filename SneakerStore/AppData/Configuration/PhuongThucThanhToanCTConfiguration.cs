using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configuration
{
    public class PhuongThucThanhToanCTConfiguration : IEntityTypeConfiguration<PhuongThucThanhToanCT>
    {
        public void Configure(EntityTypeBuilder<PhuongThucThanhToanCT> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.HoaDon).WithMany(p => p.PhuongThucThanhToanCTs).HasForeignKey(p => p.IdHD);
            builder.HasOne(p => p.PhuongThucThanhToan).WithMany(p => p.PhuongThucThanhToanCTs).HasForeignKey(p => p.IdPTTT);

    
        }
    }
}
