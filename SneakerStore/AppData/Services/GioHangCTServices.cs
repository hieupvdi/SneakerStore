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
    public class GioHangCTServices: IGioHangCTServices
    {
        public readonly SNDbcontext _dbcontext;
        public GioHangCTServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateGioHangCT(GioHangCTVM obj)
        {
            try
            {
                var ghct = new GioHangCT
                {
                    Id=Guid.NewGuid(),
                    IdUser = obj.IdUser,
                    SoLuong = 1,
                    DonGia=obj.DonGia,
                    IdCTSP=obj.IdCTSP,
                    TrangThai = 1,
                };

                await _dbcontext.AddAsync(ghct);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteGioHangCT(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var ghct = await _dbcontext.GioHangCTs.FirstOrDefaultAsync(c => c.IdUser == id);
                if (ghct != null)
                {
                    ghct.TrangThai = 0;
                    _dbcontext.Update(ghct);
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

        public async Task<bool> EditGioHangCT(GioHangCTVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var ghct = await _dbcontext.GioHangCTs.FirstOrDefaultAsync(c => c.IdUser == obj.IdUser);

                if (ghct != null)
                {
                    ghct.IdUser = obj.IdUser;
                    ghct.SoLuong = obj.SoLuong;
                    ghct.DonGia = obj.DonGia;
                    ghct.IdCTSP = obj.IdCTSP;
                    ghct.TrangThai = obj.TrangThai;

                    _dbcontext.Update(ghct);
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

        public async Task<List<GioHangCTVM>> GetGioHangCTAll()
        {


            var query = from a in _dbcontext.GioHangCTs
                        join b in _dbcontext.CTSanPhams on a.IdCTSP equals b.Id
                        join c in _dbcontext.Users on a.IdUser equals c.Id
                        select new { a, b,c };
            var data = await query
           .Select(x => new GioHangCTVM()
           {
               Id = x.a.Id,
               TenTK = x.c.TenTaiKhoan,
               SoLuong = x.a.SoLuong,
               DonGia = x.a.DonGia,
               TenSP = x.b.SanPham.TenSP,
               TrangThai = x.a.TrangThai,

           }
            ).ToListAsync();
            return data; ;

        }

        public async Task<GioHangCTVM> GetGioHangCTById(Guid id)
        {
            var ghct = await _dbcontext.GioHangCTs.AsQueryable().FirstOrDefaultAsync(c => c.IdUser == id && c.TrangThai != 0);

            if (ghct == null)
            {
                return null;
            }
            var gh = new GioHangCTVM
            {
                Id = ghct.Id,
                IdUser = ghct.IdUser,
                SoLuong = ghct.SoLuong,
                DonGia = ghct.DonGia,
                IdCTSP = ghct.IdCTSP,
                TrangThai = ghct.TrangThai,
            };

            return gh;
        }
    }
}
