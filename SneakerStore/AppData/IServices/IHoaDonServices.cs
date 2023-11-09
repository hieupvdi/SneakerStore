using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IHoaDonServices
    {
        public Task<List<HoaDonVM>> GetHoaDonAll();
        public Task<bool> CreateHoaDon(HoaDonVM obj);
        public Task<bool> EditHoaDon(HoaDonVM obj);
        public Task<bool> DeleteHoaDon(Guid id);
        public Task<HoaDonVM>GetHoaDonById(Guid id);
    }
}
