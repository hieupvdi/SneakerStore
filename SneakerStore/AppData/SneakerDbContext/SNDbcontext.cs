using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.SneakerDbContext
{
    public class SNDbcontext : DbContext
    {
        public SNDbcontext()
        {
            
        }
        public DbSet<AnhSanPham> AnhSanPhams { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<CTSanPham> CTSanPhams { get; set; }
        public DbSet<DeGiay> DeGiays { get; set; }
        public DbSet<GiamGia> GiamGias { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangCT> GioHangCTs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonCT> HoaDonCTs { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public DbSet<PhuongThucThanhToanCT> PhuongThucThanhToanCTs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DiaChi> DiaChis { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Bog> Bogs { get; set; }

        public SNDbcontext(DbContextOptions options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2V5BKJA\\SQLEXPRESS;Initial Catalog=SneakerStore;Persist Security Info=True;User ID=hieupvph27565;Password=hieupvph27565");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<GioHang>().HasKey(c => c.IDUser);
        //    builder.Entity<HoaDonChiTiet>().HasKey(c => new { c.IdCTSP, c.IdHD });
        //    builder.Entity<GioHang>().HasOne(c => c.User).WithOne(p => p.GioHang).HasForeignKey<GioHang>();
        //    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>()
                .HasOne(a => a.GioHang)
                .WithOne(b => b.User)
                .HasForeignKey<GioHang>(b => b.IdUser);
            //modelBuilder.Seed();
        }

    }
}
