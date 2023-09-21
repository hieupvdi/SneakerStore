using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppApi.Configuration
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasOne(c => c.MauSac).WithMany().HasForeignKey(c => c.IDMauSac);
            builder.HasOne(c => c.AnhSanPham).WithMany().HasForeignKey(c => c.IDAnhSanPham);
            builder.HasOne(c => c.LoaiSanPham).WithMany().HasForeignKey(c => c.IDLoaiSanPham);
            builder.HasOne(c => c.KichCo).WithMany().HasForeignKey(c => c.IDKichCo);
            builder.HasOne(c => c.GiamGia).WithMany().HasForeignKey(c => c.IDGiamGia);
           
        }
    }
}
