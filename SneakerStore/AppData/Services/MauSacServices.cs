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
    public class MauSacServices: IMauSacServices
    {
        public readonly SNDbcontext _dbcontext;
        public MauSacServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateMauSac(MauSacVM obj)
        {
            try
            {
                var ms = new MauSac
                {

                    Id = Guid.NewGuid(),
                    TenMauSac = obj.TenMauSac,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(ms);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteMauSac(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var ms = await _dbcontext.MauSacs.FirstOrDefaultAsync(c => c.Id == id);
                if (ms != null)
                {
                    ms.TrangThai = 0;
                    _dbcontext.Update(ms);
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

        public async Task<bool> EditMauSac(MauSacVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var ms = await _dbcontext.MauSacs.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (ms != null)
                {
                    //mapper
                    ms.Id = obj.Id;
                    ms.TenMauSac = obj.TenMauSac;
                    ms.TrangThai = obj.TrangThai;

                    _dbcontext.Update(ms);
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

        public async Task<List<MauSacVM>> GetMauSacAll()
        {


            var query = from c in _dbcontext.MauSacs
                        select new MauSacVM
                        {
                            Id = c.Id,
                            TenMauSac = c.TenMauSac,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<MauSacVM> GetMauSacById(Guid id)
        {
            var ms = await _dbcontext.MauSacs.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (ms == null)
            {
                return null;
            }
            var m = new MauSacVM
            {
                Id = ms.Id,
                TenMauSac = ms.TenMauSac,
                TrangThai = ms.TrangThai,
            };

            return m;
        }
    }
}
