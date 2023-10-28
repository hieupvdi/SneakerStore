using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IGiamGiaServices
    {
        public Task<List<GiamGiaVM>> GetGiamGiaAll();
        public Task<bool> CreateGiamGia(GiamGiaVM obj);
        public Task<bool> EditGiamGia(GiamGiaVM obj);
        public Task<bool> DeleteGiamGia(Guid id);
        public Task<GiamGiaVM> GetGiamGiaById(Guid id);
    }
}
