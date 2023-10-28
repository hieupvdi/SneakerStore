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
    public class PhuongThucThanhToanServices: IPhuongThucThanhToanServices
    {
        public readonly SNDbcontext _dbcontext;
        public PhuongThucThanhToanServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreatePTTT(PhuongThucThanhToanVM obj)
        {
            try
            {
                var pt = new PhuongThucThanhToan
                {

                    Id = Guid.NewGuid(),
                    Ten = obj.Ten,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(pt);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeletePTTT(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var pt = await _dbcontext.PhuongThucThanhToans.FirstOrDefaultAsync(c => c.Id == id);
                if (pt != null)
                {
                    pt.TrangThai = 0;
                    _dbcontext.Update(pt);
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

        public async Task<bool> EditPTTT(PhuongThucThanhToanVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var pt = await _dbcontext.PhuongThucThanhToans.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (pt != null)
                {
                    //mapper
                    pt.Id = obj.Id;
                    pt.Ten = obj.Ten;
                    pt.TrangThai = obj.TrangThai;

                    _dbcontext.Update(pt);
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

        public async Task<List<PhuongThucThanhToanVM>> GetPTTTAll()
        {


            var query = from c in _dbcontext.PhuongThucThanhToans
                        select new PhuongThucThanhToanVM
                        {
                            Id = c.Id,
                            Ten = c.Ten,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<PhuongThucThanhToanVM> GetPTTTById(Guid id)
        {
            var pt = await _dbcontext.PhuongThucThanhToans.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (pt == null)
            {
                return null;
            }
            var p = new PhuongThucThanhToanVM
            {
                Id = pt.Id,
                Ten = pt.Ten,
                TrangThai = pt.TrangThai,
            };

            return p;
        }
    }
}
