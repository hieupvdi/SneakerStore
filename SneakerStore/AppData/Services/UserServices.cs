using AppData.IServices;
using AppData.Models;
using AppData.SneakerDbContext;
using AppData.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
    public class UserServices: IUserServices
    {
        public readonly SNDbcontext _dbcontext;
        public UserServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateUser(UserVM obj)
        {
            try
            {
                var us = new User
                {

                    Id = Guid.NewGuid(),
                    IdCV =obj.IdCV,
                    HoTen =obj.HoTen,
                    Url =obj.Url,
                    Email=obj.Email,
                    TenTaiKhoan =obj.TenTaiKhoan,
                    MatKhau =obj.MatKhau,
                    SDT =obj.SDT,
                    IdDiaChi=obj.IdDiaChi, 
                    GioiTinh =obj.GioiTinh,
                    SoDiem =obj.SoDiem,
                    TrangThai =obj.TrangThai,
                };

                await _dbcontext.AddAsync(us);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var us = await _dbcontext.Users.FirstOrDefaultAsync(c => c.Id == id);
                if (us != null)
                {
                    us.TrangThai = 0;
                    _dbcontext.Update(us);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> EditUser(UserVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var us = await _dbcontext.Users.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (us != null)
                {
                    us.IdCV = obj.IdCV;
                    us.HoTen = obj.HoTen;
                    us.Url = obj.Url;
                    us.Email = obj.Email;
                    us.TenTaiKhoan = obj.TenTaiKhoan;
                    us.MatKhau = obj.MatKhau;
                    us.SDT = obj.SDT;
                    us.IdDiaChi = obj.IdDiaChi;
                    us.GioiTinh = obj.GioiTinh;
                    us.SoDiem = obj.SoDiem;
                    us.TrangThai = obj.TrangThai;

                    _dbcontext.Update(us);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<List<UserVM>> GetUserAll()
        {
            var query = from a in _dbcontext.Users
                        join b in _dbcontext.ChucVus on a.IdCV equals b.Id
                        join c in _dbcontext.DiaChis on a.IdDiaChi equals c.Id
                        select new { a, b, c };
            var data = await query
           .Select(x => new UserVM()
           {

               Id = x.a.Id,
               ChucVu = x.b.Ten,
               HoTen = x.a.HoTen,
               Url = x.a.Url,
               Email = x.a.Email,
               TenTaiKhoan = x.a.TenTaiKhoan,
               MatKhau = x.a.MatKhau,
               SDT = x.a.SDT,
               DiaChi = x.c.Ten,
               GioiTinh = x.a.GioiTinh,
               SoDiem = x.a.SoDiem,
               TrangThai = x.a.TrangThai,
           }
            ).ToListAsync();
            return data;
        }

        public async Task<UserVM> GetUserById(Guid id)
        {
            var us = await _dbcontext.Users.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (us == null)
            {
                return null;
            }
            var u = new UserVM
            {
                Id = us.Id,
                IdCV = us.IdCV,
                HoTen = us.HoTen,
                Url = us.Url,
                Email = us.Email,
                TenTaiKhoan = us.TenTaiKhoan,
                MatKhau = us.MatKhau,
                SDT = us.SDT,
                IdDiaChi = us.IdDiaChi,
                GioiTinh = us.GioiTinh,
                SoDiem = us.SoDiem,
                TrangThai = us.TrangThai,
            };

            return u;
        }
    }
}
