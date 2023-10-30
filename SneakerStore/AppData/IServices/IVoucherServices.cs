using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IVoucherServices
    {
        public Task<List<VoucherVM>> GetVoucherAll();
        public Task<bool> CreateVoucher(VoucherVM obj);
        public Task<bool> EditVoucher(VoucherVM obj);
        public Task<bool> DeleteVoucher(Guid id);
        public Task<VoucherVM> GetVoucherById(Guid id);
    }
}
