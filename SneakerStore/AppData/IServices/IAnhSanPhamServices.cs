using AppData.Models;
using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IAnhSanPhamServices
    {
        public Task<List<AnhSanPhamVM>> GetASPAll();
        public Task<bool> CreateASP(AnhSanPhamVM obj);
        public Task<bool> EditASP(AnhSanPhamVM obj);
        public Task<bool> DeleteASP(Guid id);
        public Task<AnhSanPhamVM> GetASPById(Guid id);
    }
}
