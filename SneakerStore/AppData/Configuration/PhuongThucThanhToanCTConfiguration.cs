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

            builder.HasOne(c => c.HoaDons).WithMany().HasForeignKey(c => c.IdHD);
            builder.HasOne(c => c.PhuongThucThanhToans).WithMany().HasForeignKey(c => c.IdPTTT);
        }
    }
}
