using AppData.IServices;
using AppData.Services;
using AppData.ViewModels;


namespace AppApi
{
    public static class ServiceRegistration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IAnhSanPhamServices, AnhSanPhamServices>();
            services.AddScoped<IChucVuServices, ChucVuServices>();
            services.AddScoped<ICTSanPhamServices, CTSanPhamServices>();
            services.AddScoped<IDanhMucServices, DanhMucServices>();
            services.AddScoped<IDeGiayServices, DeGiayServices>();
            services.AddScoped<IGiamGiaServices, GiamGiaServices>();
            services.AddScoped<IGioHangServices, GioHangServices>();
            services.AddScoped<IGioHangCTServices, GioHangCTServices>();
            services.AddScoped<IHoaDonServices, HoaDonServices>();
            services.AddScoped<IHoaDonCTServices, HoaDonCTServices>();
            services.AddScoped<IMauSacServices, MauSacServices>();
            services.AddScoped<IPhuongThucThanhToanServices, PhuongThucThanhToanServices>();
            services.AddScoped<IPhuongThucThanhToanCTServices, PhuongThucThanhToanCTServices>();
            services.AddScoped<ISanPhamServices, SanPhamServices>();
            services.AddScoped<ISizeServices, SizeServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IDiaChiServices, DiaChiServices>();
            services.AddScoped<IVoucherServices, VoucherServices>();
            services.AddScoped<IBlogServices, BlogServices>();


		
		}
	}
}
