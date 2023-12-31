﻿using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configuration
{
    public class AnhSanPhamConfiguration :IEntityTypeConfiguration<AnhSanPham>
    {
        public void Configure(EntityTypeBuilder<AnhSanPham> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(p => p.CTSanPham).WithMany(p => p.AnhSanPhams).HasForeignKey(p => p.IdCTSP);
        }
    }
}
