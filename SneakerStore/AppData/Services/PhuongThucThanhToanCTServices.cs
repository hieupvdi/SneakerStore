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
    public class PhuongThucThanhToanCTServices: IPhuongThucThanhToanCTServices
    {
        public readonly SNDbcontext _dbcontext;
        public PhuongThucThanhToanCTServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreatePTTTCT(PhuongThucThanhToanCTVM obj)
        {
            try
            {
                var ptct = new PhuongThucThanhToanCT
                {

                    Id = Guid.NewGuid(),
                    IdHD = obj.IdHD,
                    IdPTTT = obj.IdPTTT,
                    SoTien=obj.SoTien,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(ptct);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeletePTTTCT(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var ptct = await _dbcontext.PhuongThucThanhToanCTs.FirstOrDefaultAsync(c => c.Id == id);
                if (ptct != null)
                {
                    ptct.TrangThai = 0;
                    _dbcontext.Update(ptct);
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

        public async Task<bool> EditPTTTCT(PhuongThucThanhToanCTVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var ptct = await _dbcontext.PhuongThucThanhToanCTs.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (ptct != null)
                {
                
                    ptct.IdHD = obj.IdHD;
                    ptct.IdPTTT = obj.IdPTTT;
                    ptct.SoTien = obj.SoTien;
                    ptct.TrangThai = obj.TrangThai;

                    _dbcontext.Update(ptct);
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

        public async Task<List<PhuongThucThanhToanCTVM>> GetPTTTCTAll()
        {
            var query = from a in _dbcontext.PhuongThucThanhToanCTs
                        join b in _dbcontext.PhuongThucThanhToans on a.IdPTTT equals b.Id
                        join c in _dbcontext.HoaDons on a.IdHD equals c.Id
                        select new { a, b, c };
            var data = await query
           .Select(x => new PhuongThucThanhToanCTVM()
           {
               Id =x.a.Id,
               MaHD = x.c.MaHD,
               TenPT = x.b.Ten,
               SoTien = x.a.SoTien,
               TrangThai = x.a.TrangThai,

           }
            ).ToListAsync();
            return data;
        }

        public async Task<PhuongThucThanhToanCTVM> GetPTTTCTById(Guid id)
        {
            var ptct = await _dbcontext.PhuongThucThanhToanCTs.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (ptct == null)
            {
                return null;
            }
            var pt = new PhuongThucThanhToanCTVM
            {
                Id = ptct.Id,
                IdHD = ptct.IdHD,
                IdPTTT = ptct.IdPTTT,
                SoTien = ptct.SoTien,
                TrangThai = ptct.TrangThai,
        };

            return pt;
        }
    }
}
