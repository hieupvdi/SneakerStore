using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppApi.Configuration
{
    public class DiaChiConfiguration : IEntityTypeConfiguration<DiaChi>
    {
        public void Configure(EntityTypeBuilder<DiaChi> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.IDUser);
        }
    }
}
