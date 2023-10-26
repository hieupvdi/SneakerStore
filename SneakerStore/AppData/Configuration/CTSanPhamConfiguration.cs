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
            builder.HasOne(c => c.SanPhams).WithMany().HasForeignKey(c => c.IdSP);
            builder.HasOne(c => c.KichCos).WithMany().HasForeignKey(c => c.IdKichCo);
            builder.HasOne(c => c.MauSacs).WithMany().HasForeignKey(c => c.IdMauSac);
            builder.HasOne(c => c.LoaiSanPhams).WithMany().HasForeignKey(c => c.IdLoaiSanPham);
            builder.HasOne(c => c.DeGiays).WithMany().HasForeignKey(c => c.IdDeGiay);
            builder.HasOne(c => c.GiamGias).WithMany().HasForeignKey(c => c.IdGiamGia);
           
        }
    }
}
