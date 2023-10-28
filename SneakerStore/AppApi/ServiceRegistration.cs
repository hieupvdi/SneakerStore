using AppData.IServices;
using AppData.Services;

namespace AppApi
{
    public static class ServiceRegistration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IChucVuServices, ChucVuServices>();
       

        }
    }
}
