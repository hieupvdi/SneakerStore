using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IDiaChiServices
    {
        public Task<List<DiaChiVM>> GetDiaChiAll();
        public Task<bool> CreateDiaChi(DiaChiVM obj);
        public Task<bool> EditDiaChi(DiaChiVM obj);
        public Task<bool> DeleteDiaChi(Guid id);
        public Task<DiaChiVM> GetDiaChiById(Guid id);
    }
}
