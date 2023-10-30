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
    public class GiamGiaServices: IGiamGiaServices
    {
        public readonly SNDbcontext _dbcontext;
        public GiamGiaServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateGiamGia(GiamGiaVM obj)
        {
            try
            {
                var gg = new GiamGia
                {

                    Id = Guid.NewGuid(),
                    TenMaGiamGia = obj.TenMaGiamGia,
                    NgayBatDau = obj.NgayBatDau,
                    NgayKetThuc=obj.NgayKetThuc,
                    PhamTram=obj.PhamTram,
                    MoTa=obj.MoTa,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(gg);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteGiamGia(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var gg = await _dbcontext.GiamGias.FirstOrDefaultAsync(c => c.Id == id);
                if (gg != null)
                {
                    gg.TrangThai = 0;
                    _dbcontext.Update(gg);
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

        public async Task<bool> EditGiamGia(GiamGiaVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var gg = await _dbcontext.GiamGias.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (gg != null)
                {
                    //mapper
                    gg.Id = obj.Id;
                    gg.TenMaGiamGia = obj.TenMaGiamGia;
                    gg.NgayBatDau = obj.NgayBatDau;
                    gg.NgayKetThuc = obj.NgayKetThuc;
                    gg.PhamTram = obj.PhamTram;
                    gg.MoTa = obj.MoTa;
                    gg.TrangThai = obj.TrangThai;

                    _dbcontext.Update(gg);
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

        public async Task<List<GiamGiaVM>> GetGiamGiaAll()
        {


            var query = from c in _dbcontext.GiamGias
                        select new GiamGiaVM
                        {
                            Id = c.Id,
                            TenMaGiamGia = c.TenMaGiamGia,
                            NgayBatDau = c.NgayBatDau,
                            NgayKetThuc = c.NgayKetThuc,
                            PhamTram = c.PhamTram,
                            MoTa = c.MoTa,
                            TrangThai = c.TrangThai,
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<GiamGiaVM> GetGiamGiaById(Guid id)
        {
            var gg = await _dbcontext.GiamGias.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (gg == null)
            {
                return null;
            }
            var g = new GiamGiaVM
            {
                Id = gg.Id,
                TenMaGiamGia = gg.TenMaGiamGia,
                NgayBatDau = gg.NgayBatDau,
                NgayKetThuc = gg.NgayKetThuc,
                PhamTram = gg.PhamTram,
                MoTa = gg.MoTa,
                TrangThai = gg.TrangThai,
            };

            return g;
        }
    }
}
