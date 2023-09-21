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
    public class AnhSanPhamConfiguration :IEntityTypeConfiguration<AnhSanPham>
    {
        public void Configure(EntityTypeBuilder<AnhSanPham> builder)
        {
            builder.HasKey(c => c.ID);
        }
    }
}
