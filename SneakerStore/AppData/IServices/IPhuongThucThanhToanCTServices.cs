using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IPhuongThucThanhToanCTServices
    {
        public Task<List<PhuongThucThanhToanCTVM>> GetPTTTCTAll();
        public Task<bool> CreatePTTTCT(PhuongThucThanhToanCTVM obj);
        public Task<bool> EditPTTTCT(PhuongThucThanhToanCTVM obj);
        public Task<bool> DeletePTTTCT(Guid id);
        public Task<PhuongThucThanhToanCTVM> GetPTTTCTById(Guid id);
    }
}
