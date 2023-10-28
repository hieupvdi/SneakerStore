using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IDeGiayServices
    {
        public Task<List<DeGiayVM>> GetDeGiayAll();
        public Task<bool> CreateDeGiay(DeGiayVM obj);
        public Task<bool> EditDeGiay(DeGiayVM obj);
        public Task<bool> DeleteDeGiay(Guid id);
        public Task<DeGiayVM> GetDeGiayById(Guid id);
    }
}
