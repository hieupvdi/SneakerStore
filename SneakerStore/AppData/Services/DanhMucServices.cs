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
    public class DanhMucServices: IDanhMucServices
    {
        public readonly SNDbcontext _dbcontext;
        public DanhMucServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateDanhMuc(DanhMucVM obj)
        {
            try
            {
                var dm = new DanhMuc
                {

                    Id = Guid.NewGuid(),
                    Ten = obj.Ten,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(dm);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteDanhMuc(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var dm = await _dbcontext.DanhMucs.FirstOrDefaultAsync(c => c.Id == id);
                if (dm != null)
                {
                    dm.TrangThai = 0;
                    _dbcontext.Update(dm);
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

        public async Task<bool> EditDanhMuc(DanhMucVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var dm = await _dbcontext.DanhMucs.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (dm != null)
                {
                    //mapper
                    dm.Id = obj.Id;
                    dm.Ten = obj.Ten;
                    dm.TrangThai = obj.TrangThai;

                    _dbcontext.Update(dm);
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

        public async Task<List<DanhMucVM>> GetDanhMucAll()
        {


            var query = from c in _dbcontext.DanhMucs
                        select new DanhMucVM
                        {
                            Id = c.Id,
                            Ten = c.Ten,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<DanhMucVM> GetDanhMucById(Guid id)
        {
            var dm = await _dbcontext.DanhMucs.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (dm == null)
            {
                return null;
            }
            var d = new DanhMucVM
            {
                Id = dm.Id,
                Ten = dm.Ten,
                TrangThai = dm.TrangThai,
            };

            return d;
        }
    }
}
