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
            builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.IdUser);
            builder.HasOne(c => c.Voucher).WithMany().HasForeignKey(c => c.IdVoucher);
        }
    }
}
