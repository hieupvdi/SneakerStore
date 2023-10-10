using AppApi.IRepositories;
using AppApi.Repositories;


namespace AppApi
{
    public static class ServiceRegistration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
            services.AddScoped<IMauSacRepository, MauSacRepository>();
            services.AddScoped<IKichCoRepository, KichCoRepository>();
            services.AddScoped<ILoaiSanPhamRepository, LoaiSanPhamRepository>();
            services.AddScoped<IAnhSanPhamRepository, AnhSanPhamRepository>();
            services.AddScoped<IGiamGiaRepository, GiamGiaRepository>();

        }
    }
}
