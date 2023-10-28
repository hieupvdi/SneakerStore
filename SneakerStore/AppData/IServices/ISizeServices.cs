using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface ISizeServices
    {
        public Task<List<SizeVM>> GetSizeAll();
        public Task<bool> CreateSize(SizeVM obj);
        public Task<bool> EditSize(SizeVM obj);
        public Task<bool> DeleteSize(Guid id);
        public Task<SizeVM> GetSizeById(Guid id);
    }
}
