using AppData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace AppApi.SneakerDbContext
{
    public class SNDbcontext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public SNDbcontext()
        {
            
        }

        public SNDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AnhSanPham> AnhSanPhams { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }  
        public DbSet<DiaChi> DiaChis { get; set; }  
        public DbSet<GiamGia> GiamGias { get; set; }  
        public DbSet<GioHang> GioHangs { get; set; }  
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }  
        public DbSet<HoaDon> HoaDons { get; set; }  
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }  
        public DbSet<KichCo> KichCos { get; set; }  
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }  
        public DbSet<MauSac> MauSacs { get; set; }  
        public DbSet<SanPham> SanPhams { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GioHang>().HasKey(c => c.IDUser);
            builder.Entity<HoaDonChiTiet>().HasKey(c => new { c.IDSanPham, c.IDHoaDon });
            builder.Entity<GioHang>().HasOne(c => c.User).WithOne(p => p.GioHang).HasForeignKey<GioHang>();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
