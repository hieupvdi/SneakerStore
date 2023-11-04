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
    public class SizeServices: ISizeServices
    {
        public readonly SNDbcontext _dbcontext;
        public SizeServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateSize(SizeVM obj)
        {
            try
            {
                var kc = new Size
                {

                    Id = Guid.NewGuid(),
                    SizeNumber = obj.SizeNumber,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(kc);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteSize(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var kc = await _dbcontext.Sizes.FirstOrDefaultAsync(c => c.Id == id);
                if (kc != null)
                {
                    kc.TrangThai = 0;
                    _dbcontext.Update(kc);
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

        public async Task<bool> EditSize(SizeVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var kc = await _dbcontext.Sizes.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (kc != null)
                {
                    //mapper
                    kc.Id = obj.Id;
                    kc.SizeNumber = obj.SizeNumber;
                    kc.TrangThai = obj.TrangThai;

                    _dbcontext.Update(kc);
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

        public async Task<List<SizeVM>> GetSizeAll()
        {


            var query = from c in _dbcontext.Sizes
                        select new SizeVM
                        {
                            Id = c.Id,
                            SizeNumber = c.SizeNumber,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<SizeVM> GetSizeById(Guid id)
        {
            var kc = await _dbcontext.Sizes.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (kc == null)
            {
                return null;
            }
            var k = new SizeVM
            {
                Id = kc.Id,
                SizeNumber =kc.SizeNumber,
                TrangThai = kc.TrangThai,
            };

            return k;
        }
    }
}
