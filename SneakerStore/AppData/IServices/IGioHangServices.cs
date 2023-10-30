using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IGioHangServices
    {
        public Task<List<GioHangVM>> GetGioHangAll();
        public Task<bool> CreateGioHang(GioHangVM obj);
        public Task<bool> EditGioHang(GioHangVM obj);
        public Task<bool> DeleteGioHang(Guid id);
        public Task<GioHangVM> GetGioHangById(Guid id);
    }
}
