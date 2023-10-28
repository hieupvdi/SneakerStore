using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IChucVuServices
    {
        public Task<List<ChucVuVM>> GetChucVuAll();
        public Task<bool> CreateChucVu(ChucVuVM obj);
        public Task<bool> EditChucVu(ChucVuVM obj);
        public Task<bool> DeleteChucVu(Guid id);
        public Task<ChucVuVM> GetChucVuById(Guid id);
    }
}
