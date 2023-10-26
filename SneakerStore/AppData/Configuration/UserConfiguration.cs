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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);       
            builder.HasOne(p => p.ChucVu).WithMany(p => p.Users).HasForeignKey(p => p.IdCV);
            builder.HasAlternateKey(p => p.TenTaiKhoan); // Unique
        }
    }
}
