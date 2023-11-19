using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IUserServices
    {
        public Task<List<UserVM>> GetUserAll();
        public Task<bool> CreateUser(UserVM obj);
        public Task<bool> EditUser(UserVM obj);
        public Task<bool> DeleteUser(Guid id);
        public Task<UserVM> GetUserById(Guid id);
        public Task<UserVM> GetTenTaiKhoan(string TenTaiKhoan);
        public Task<Guid> Dangnhap(string TenTaiKhoan ,string MatKhau);
    }
}
