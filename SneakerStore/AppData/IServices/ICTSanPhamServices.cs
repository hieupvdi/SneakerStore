using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface ICTSanPhamServices
    {
        public Task<List<CTSanPhamVM>> GetCTSanPhamAll();
        public Task<bool> CreateCTSanPham(CTSanPhamVM obj);
        public Task<bool> EditCTSanPham(CTSanPhamVM obj);
        public Task<bool> DeleteCTSanPham(Guid id);
        public Task<CTSanPhamVM> GetCTSanPhamById(Guid id);
    }
}
