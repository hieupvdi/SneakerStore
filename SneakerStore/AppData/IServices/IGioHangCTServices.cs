using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IGioHangCTServices
    {
        public Task<List<GioHangCTVM>> GetGioHangCTAll();
        public Task<bool> CreateGioHangCT(GioHangCTVM obj);
        public Task<bool> EditGioHangCT(GioHangCTVM obj);
        public Task<bool> DeleteGioHangCT(Guid id);
        public Task<GioHangCTVM> GetGioHangCTById(Guid iduser, Guid idctsp);
        public Task<List<GioHangCTVM>> GetGioHangCTUser(Guid id);
    }
}
