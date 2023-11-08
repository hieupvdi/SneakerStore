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
    public class HoaDonCTServices: IHoaDonCTServices
    {
        public readonly SNDbcontext _dbcontext;
        public HoaDonCTServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateHoaDonCT(HoaDonCTVM obj)
        {
            try
            {
                var hdct = new HoaDonCT
                {

                    Id = Guid.NewGuid(),
                    IdHD = obj.IdHD,
                    IdCTSP = obj.IdCTSP,
                    SoLuong = obj.SoLuong,
                    DonGia= obj.DonGia,        
                    TrangThai = obj.TrangThai,
                };
                
                await _dbcontext.AddAsync(hdct);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteHoaDonCT(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var hdct = await _dbcontext.HoaDonCTs.FirstOrDefaultAsync(c => c.Id == id);
                if (hdct != null)
                {
                    hdct.TrangThai = 0;
                    _dbcontext.Update(hdct);
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

        public async Task<bool> EditHoaDonCT(HoaDonCTVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var hdct = await _dbcontext.HoaDonCTs.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (hdct != null)
                {

                
                    hdct.IdHD = obj.IdHD;
                    hdct.IdCTSP = obj.IdCTSP;
                    hdct.SoLuong = obj.SoLuong;
                    hdct.DonGia = obj.DonGia;
                    hdct.TrangThai = obj.TrangThai;
                 

                    _dbcontext.Update(hdct);
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

        public async Task<List<HoaDonCTVM>> GetHoaDonCTAll()
        {
            var query = from a in _dbcontext.HoaDonCTs
                        join b in _dbcontext.HoaDons on a.IdHD equals b.Id
                        join c in _dbcontext.CTSanPhams on a.IdCTSP equals c.Id

                        select new { a, b, c };
            var data = await query
           .Select(x => new HoaDonCTVM()
           {
               Id = x.a.Id,
               MaHD = x.b.MaHD,
               TenSP = x.c.SanPham.TenSP,
               SoLuong = x.a.SoLuong,
               DonGia = x.a.DonGia,
               TrangThai = x.a.TrangThai,

           }
            ).ToListAsync();
            return data;
        }

        public async Task<HoaDonCTVM> GetHoaDonCTById(Guid id)
        {
            var hdct = await _dbcontext.HoaDonCTs.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (hdct == null)
            {
                return null;
            }
            var hd = new HoaDonCTVM
            {
                Id = hdct.Id,
                IdHD = hdct.IdHD,
                IdCTSP = hdct.IdCTSP,
                SoLuong = hdct.SoLuong,
                DonGia = hdct.DonGia,
                TrangThai = hdct.TrangThai,
            };

            return hd;
        }
    }
}
