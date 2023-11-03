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
    public class AnhSanPhamServices : IAnhSanPhamServices
    {
        public readonly SNDbcontext _dbcontext;
        public AnhSanPhamServices()
        {
            _dbcontext=new SNDbcontext();
        }
        public async Task<bool> CreateASP(AnhSanPhamVM obj)
        {
            try
            {
                var asp = new AnhSanPham
                {
                    
                    Id = Guid.NewGuid(),
                    IdCTSP=obj.IdCTSP,
                    URlAnh = obj.URlAnh,
					AnhSo = obj.AnhSo,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(asp);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteASP(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var asp = await _dbcontext.AnhSanPhams.FirstOrDefaultAsync(c => c.Id == id);
                if (asp != null)
                {
                    asp.TrangThai = 0;
                    _dbcontext.Update(asp);
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

        public async Task<bool> EditASP(AnhSanPhamVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var asp = await _dbcontext.AnhSanPhams.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (asp != null)
                {
                    //mapper
                    asp.Id = obj.Id;
                    asp.IdCTSP=obj.IdCTSP;
                    asp.URlAnh = obj.URlAnh;
                    asp.AnhSo=obj.AnhSo;
                    asp.TrangThai = obj.TrangThai;

                    _dbcontext.Update(asp);
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

        public async Task<List<AnhSanPhamVM>> GetASPAll()
        {
            var query = from a in _dbcontext.AnhSanPhams
                        join b in _dbcontext.CTSanPhams on a.IdCTSP equals b.Id                    
                        select new { a, b };
            var data = await query
           .Select(x => new AnhSanPhamVM()
           {
               Id = x.a.Id,
               IdCTSP = x.a.IdCTSP,
               Tensp=x.b.SanPham.TenSP,
               URlAnh = x.a.URlAnh,        
               TrangThai = x.a.TrangThai,

           }
            ).ToListAsync();
            return data;
        }

        public async Task<AnhSanPhamVM> GetASPById(Guid id)
        {
            var asp = await _dbcontext.AnhSanPhams.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (asp == null)
            {
                return null;
            }       
            var Anhsp = new AnhSanPhamVM
            {
                Id = asp.Id,
                URlAnh = asp.URlAnh,
                TrangThai = asp.TrangThai,
            };

            return Anhsp;
        }
    }
}
