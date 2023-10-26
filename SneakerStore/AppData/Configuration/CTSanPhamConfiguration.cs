using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Configuration
{
    public class CTSanPhamConfiguration : IEntityTypeConfiguration<CTSanPham>
    {
        public void Configure(EntityTypeBuilder<CTSanPham> builder)
        {
            builder.HasKey(c => c.Id);


            builder.HasOne(p => p.SanPham).WithMany(p => p.CTSanPhams).HasForeignKey(p => p.IdSP);
            builder.HasOne(p => p.KichCo).WithMany(p => p.CTSanPhams).HasForeignKey(p => p.IdKichCo);
            builder.HasOne(p => p.MauSac).WithMany(p => p.CTSanPhams).HasForeignKey(p => p.IdMauSac);
            builder.HasOne(p => p.LoaiSanPham).WithMany(p => p.CTSanPhams).HasForeignKey(p => p.IdLoaiSanPham);
            builder.HasOne(p => p.DeGiay).WithMany(p => p.CTSanPhams).HasForeignKey(p => p.IdDeGiay);     
            builder.HasOne(p => p.GiamGia).WithMany(p => p.CTSanPhams).HasForeignKey(p => p.IdGiamGia);
       
        }
    }
}
