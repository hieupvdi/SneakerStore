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
    public class GioHangServices: IGioHangServices
    {
        public readonly SNDbcontext _dbcontext;
        public GioHangServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateGioHang(GioHangVM obj)
        {
            try
            {
                var gh = new GioHang
                {

                    IdUser = obj.IdUser,               
                    MoTa = obj.MoTa,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(gh);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteGioHang(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var gh = await _dbcontext.GioHangs.FirstOrDefaultAsync(c => c.IdUser == id);
                if (gh != null)
                {
                    gh.TrangThai = 0;
                    _dbcontext.Update(gh);
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

        public async Task<bool> EditGioHang(GioHangVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var gh = await _dbcontext.GioHangs.FirstOrDefaultAsync(c => c.IdUser == obj.IdUser);

                if (gh != null)
                {
                    //mapper
                    gh.IdUser = obj.IdUser;
                 
                    gh.MoTa = obj.MoTa;
                    gh.TrangThai = obj.TrangThai;

                    _dbcontext.Update(gh);
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

        public async Task<List<GioHangVM>> GetGioHangAll()
        {


            var query = from c in _dbcontext.GioHangs
                        select new GioHangVM
                        {
                            IdUser = c.IdUser,
                            MoTa = c.MoTa,
                            TrangThai = c.TrangThai,
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<GioHangVM> GetGioHangById(Guid id)
        {
            var gh = await _dbcontext.GioHangs.AsQueryable().FirstOrDefaultAsync(c => c.IdUser == id && c.TrangThai != 0);

            if (gh == null)
            {
                return null;
            }
            var g = new GioHangVM
            {
                IdUser = gh.IdUser,        
                MoTa = gh.MoTa,
                TrangThai = gh.TrangThai,
            };

            return g;
        }
    }
}
