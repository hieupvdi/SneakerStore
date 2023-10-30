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
    public class DiaChiServices: IDiaChiServices
    {
        public readonly SNDbcontext _dbcontext;
        public DiaChiServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateDiaChi(DiaChiVM obj)
        {
            try
            {
                var dc = new DiaChi
                {

                    Id = Guid.NewGuid(),
                    Ten = obj.Ten,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(dc);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteDiaChi(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var dc = await _dbcontext.DiaChis.FirstOrDefaultAsync(c => c.Id == id);
                if (dc != null)
                {
                    dc.TrangThai = 0;
                    _dbcontext.Update(dc);
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

        public async Task<bool> EditDiaChi(DiaChiVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var dc = await _dbcontext.DiaChis.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (dc != null)
                {

                    dc.Ten = obj.Ten;
                    dc.TrangThai = obj.TrangThai;

                    _dbcontext.Update(dc);
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

        public async Task<List<DiaChiVM>> GetDiaChiAll()
        {


            var query = from c in _dbcontext.DiaChis
                        select new DiaChiVM
                        {
                            Id = c.Id,
                            Ten = c.Ten,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<DiaChiVM> GetDiaChiById(Guid id)
        {
            var dc = await _dbcontext.DiaChis.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (dc == null)
            {
                return null;
            }
            var d = new DiaChiVM
            {
                Id = dc.Id,
                Ten = dc.Ten,
                TrangThai = dc.TrangThai,
            };

            return d;
        }
    }
}
