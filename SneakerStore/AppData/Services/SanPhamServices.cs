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
    public class SanPhamServices:ISanPhamServices
    {
        public readonly SNDbcontext _dbcontext;
        public SanPhamServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateSanPham(SanPhamVM obj)
        {
            try
            {
                var sp = new SanPham
                {

                    Id = Guid.NewGuid(),
                    TenSP = obj.TenSP,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(sp);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteSanPham(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var sp = await _dbcontext.SanPhams.FirstOrDefaultAsync(c => c.Id == id);
                if (sp != null)
                {
                    sp.TrangThai = 0;
                    _dbcontext.Update(sp);
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

        public async Task<bool> EditSanPham(SanPhamVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var sp = await _dbcontext.SanPhams.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (sp != null)
                {
                    //mapper
                    sp.Id = obj.Id;
                    sp.TenSP = obj.TenSP;
                    sp.TrangThai = obj.TrangThai;

                    _dbcontext.Update(sp);
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

        public async Task<List<SanPhamVM>> GetSanPhamAll()
        {


            var query = from c in _dbcontext.SanPhams
                        select new SanPhamVM
                        {
                            Id = c.Id,
                            TenSP = c.TenSP,
                            TrangThai = c.TrangThai
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<SanPhamVM> GetSanPhamById(Guid id)
        {
            var sp = await _dbcontext.SanPhams.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (sp == null)
            {
                return null;
            }
            var s = new SanPhamVM
            {
                Id = sp.Id,
                TenSP = sp.TenSP,
                TrangThai = sp.TrangThai,
            };

            return s;
        }
    }
}
