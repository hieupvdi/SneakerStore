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
    public class HoaDonConfiguration :IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.User).WithMany(p => p.HoaDons).HasForeignKey(p => p.IdUser);
            builder.HasOne(p => p.Voucher).WithMany(p => p.HoaDons).HasForeignKey(p => p.IdVoucher);

        }
    }
}
