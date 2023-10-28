using AppData.Models;
using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IDanhMucServices
    {
        public Task<List<DanhMucVM>> GetDanhMucAll();
        public Task<bool> CreateDanhMuc(DanhMucVM obj);
        public Task<bool> EditDanhMuc(DanhMucVM obj);
        public Task<bool> DeleteDanhMuc(Guid id);
        public Task<DanhMucVM> GetDanhMucById(Guid id);
    }
}
