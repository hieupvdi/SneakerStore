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
    public class DeGiayServices: IDeGiayServices
    {
        public readonly SNDbcontext _dbcontext;
        public DeGiayServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateDeGiay(DeGiayVM obj)
        {
            try
            {
                var dg = new DeGiay
                {

                    Id = Guid.NewGuid(),
                    Name = obj.Name,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(dg);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteDeGiay(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var dg = await _dbcontext.DeGiays.FirstOrDefaultAsync(c => c.Id == id);
                if (dg != null)
                {
                    dg.TrangThai = 0;
                    _dbcontext.Update(dg);
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

        public async Task<bool> EditDeGiay(DeGiayVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var dg = await _dbcontext.DeGiays.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (dg != null)
                {
                    //mapper
                    dg.Id = obj.Id;
                    dg.Name = obj.Name;
                    dg.TrangThai = obj.TrangThai;

                    _dbcontext.Update(dg);
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

        public async Task<List<DeGiayVM>> GetDeGiayAll()
        {


            var query = from c in _dbcontext.DeGiays
                        select new DeGiayVM
                        {
                            Id = c.Id,
                            Name = c.Name,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<DeGiayVM> GetDeGiayById(Guid id)
        {
            var dg = await _dbcontext.DeGiays.AsQueryable().FirstOrDefaultAsync(c => c.Id == id&& c.TrangThai!=0);

            if (dg == null)
            {
                return null;
            }
            var d = new DeGiayVM
            {
                Id = dg.Id,
                Name = dg.Name,
                TrangThai = dg.TrangThai,
            };

            return d;
        }
    }
}
