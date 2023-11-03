using AppData.IServices;
using AppData.Models;
using AppData.SneakerDbContext;
using AppData.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppData.Services
{
    public class ChucVuServices : IChucVuServices
    {

        public readonly SNDbcontext _dbcontext;
        public ChucVuServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateChucVu(ChucVuVM obj)
        {
            try
            {
                var cv = new ChucVu
                {

                    Id = Guid.NewGuid(),
                    Ten = obj.Ten,        
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(cv);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteChucVu(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var cv = await _dbcontext.ChucVus.FirstOrDefaultAsync(c => c.Id == id);
                if (cv != null)
                {
                    cv.TrangThai = 0;
                    _dbcontext.Update(cv);
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

        public async Task<bool> EditChucVu(ChucVuVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var cv = await _dbcontext.ChucVus.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (cv != null)
                {
                    
                    cv.Ten = obj.Ten;
                    cv.TrangThai = obj.TrangThai;

                    _dbcontext.Update(cv);
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

        public async Task<List<ChucVuVM>> GetChucVuAll()
        {
         

            var query = from c in _dbcontext.ChucVus
                        select new ChucVuVM
                        {
                            Id = c.Id,
                            Ten=c.Ten,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<ChucVuVM> GetChucVuById(Guid id)
        {
            var cv = await _dbcontext.ChucVus.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (cv == null)
            {
                return null;
            }
            var c = new ChucVuVM
            {
                Id = cv.Id,
                Ten = cv.Ten,
                TrangThai = cv.TrangThai,
            };

            return c;

        }
    }
}
