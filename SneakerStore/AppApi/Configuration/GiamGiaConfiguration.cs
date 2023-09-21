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
    public class GiamGiaConfiguration :IEntityTypeConfiguration<GiamGia>
    {
        public void Configure(EntityTypeBuilder<GiamGia> builder)
        {
            builder.HasKey(c => c.ID);
          
        }
    }
}
