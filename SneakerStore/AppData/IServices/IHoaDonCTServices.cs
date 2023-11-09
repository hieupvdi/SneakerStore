using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IHoaDonCTServices
    {
        public Task<List<HoaDonCTVM>> GetHoaDonCTAll();
        public Task<bool> CreateHoaDonCT(HoaDonCTVM obj);
        public Task<bool> EditHoaDonCT(HoaDonCTVM obj);
        public Task<bool> DeleteHoaDonCT(Guid id);
        public Task<HoaDonCTVM> GetHoaDonCTById(Guid id);
        public Task<List<HoaDonCTVM>> GetHDCTUser(Guid id);
    }
}
