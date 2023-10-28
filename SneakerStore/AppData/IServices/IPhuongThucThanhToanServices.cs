using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IPhuongThucThanhToanServices
    {
        public Task<List<PhuongThucThanhToanVM>> GetPTTTAll();
        public Task<bool> CreatePTTT(PhuongThucThanhToanVM obj);
        public Task<bool> EditPTTT(PhuongThucThanhToanVM obj);
        public Task<bool> DeletePTTT(Guid id);
        public Task<PhuongThucThanhToanVM> GetPTTTById(Guid id);
    }
}
