using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface ISanPhamServices
    {
        public Task<List<SanPhamVM>> GetSanPhamAll();
        public Task<bool> CreateSanPham(SanPhamVM obj);
        public Task<bool> EditSanPham(SanPhamVM obj);
        public Task<bool> DeleteSanPham(Guid id);
        public Task<SanPhamVM> GetSanPhamById(Guid id);
    }
}
