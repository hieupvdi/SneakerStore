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
    public class BogConfiguration : IEntityTypeConfiguration<Bog>
    {
        public void Configure(EntityTypeBuilder<Bog> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(p => p.User).WithMany(p => p.Bogs).HasForeignKey(p => p.IdUser);
        }
    }
}
