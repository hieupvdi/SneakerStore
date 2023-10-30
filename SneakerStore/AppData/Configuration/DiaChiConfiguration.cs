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
    public class DiaChiConfiguration : IEntityTypeConfiguration<DiaChi>
    {
        public void Configure(EntityTypeBuilder<DiaChi> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
