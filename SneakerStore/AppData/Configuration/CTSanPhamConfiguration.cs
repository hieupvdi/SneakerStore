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
            builder.HasOne(c => c.SanPham).WithMany().HasForeignKey(c => c.IdSP);
            builder.HasOne(c => c.KichCo).WithMany().HasForeignKey(c => c.IdKichCo);
            builder.HasOne(c => c.MauSac).WithMany().HasForeignKey(c => c.IdMauSac);
            builder.HasOne(c => c.LoaiSanPham).WithMany().HasForeignKey(c => c.IdLoaiSanPham);
            builder.HasOne(c => c.DeGiay).WithMany().HasForeignKey(c => c.IdDeGiay);
            builder.HasOne(c => c.GiamGia).WithMany().HasForeignKey(c => c.IdGiamGia);
           
        }
    }
}
