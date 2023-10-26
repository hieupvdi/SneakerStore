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
            builder.HasOne(c => c.CTSanPhams).WithMany().HasForeignKey(c => c.IdCTSP);
            builder.HasOne(c => c.GioHangs).WithMany().HasForeignKey(c => c.IDUser);
        }
    }
}
