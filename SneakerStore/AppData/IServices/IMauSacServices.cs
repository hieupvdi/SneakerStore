using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IMauSacServices
    {
        public Task<List<MauSacVM>> GetMauSacAll();
        public Task<bool> CreateMauSac(MauSacVM obj);
        public Task<bool> EditMauSac(MauSacVM obj);
        public Task<bool> DeleteMauSac(Guid id);
        public Task<MauSacVM> GetMauSacById(Guid id);
    }
}
