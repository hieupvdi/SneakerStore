using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IBogServices
    {
        public Task<List<BogVM>> GetBogAll();
        public Task<bool> CreateBog(BogVM obj);
        public Task<bool> EditBog(BogVM obj);
        public Task<bool> DeleteBog(Guid id);
        public Task<BogVM> GetBogById(Guid id);
    }
}
