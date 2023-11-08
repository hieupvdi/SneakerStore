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
    public class HoaDonServices: IHoaDonServices
    {
        public readonly SNDbcontext _dbcontext;
        public HoaDonServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateHoaDon(HoaDonVM obj)
        {
            try
            {
                var hd = new HoaDon
                {

                    Id = Guid.NewGuid(),
                    IdUser = obj.IdUser,
                    IdVoucher = obj.IdVoucher,
                    MaHD = obj.MaHD,
                    NgayTao = obj.NgayTao,
                    NgayNhan = obj.NgayNhan,
                    NgayThanhToan = obj.NgayThanhToan,
                    NgayShip = obj.NgayShip,
                    NguoiNhan = obj.NguoiNhan,
                    DiaChi = obj.DiaChi,
                    SDT=obj.SDT,
                    SoDiemSD = obj.SoDiemSD,
                    TienShip = obj.TienShip,
                    TongTien=obj.TongTien,
                   
                    TrangThai = obj.TrangThai,
                };
                //0 xoa 1 hoa don cho 2 chua thanh toan   3 da thanh toan
                await _dbcontext.AddAsync(hd);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteHoaDon(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var hd = await _dbcontext.HoaDons.FirstOrDefaultAsync(c => c.Id == id);
                if (hd != null)
                {
                    hd.TrangThai = 0;
                    _dbcontext.Update(hd);
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

        public async Task<bool> EditHoaDon(HoaDonVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var hd = await _dbcontext.HoaDons.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (hd != null)
                {

                    hd.IdUser = obj.IdUser;
                    hd.IdVoucher = obj.IdVoucher;
                    hd.MaHD = obj.MaHD;
                    hd.NgayTao = obj.NgayTao;
                    hd.NgayNhan = obj.NgayNhan;
                    hd.NgayThanhToan = obj.NgayThanhToan;
                    hd.NgayShip = obj.NgayShip;
                    hd.NguoiNhan = obj.NguoiNhan;
                    hd.DiaChi = obj.DiaChi;
                    hd.SDT = obj.SDT;
                    hd.SoDiemSD = obj.SoDiemSD;
                    hd.TienShip = obj.TienShip;
                    hd.TongTien = obj.TongTien;
                    hd.TrangThai = obj.TrangThai;

                    _dbcontext.Update(hd);
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

        public async Task<List<HoaDonVM>> GetHoaDonAll()
        {
            var query = from a in _dbcontext.HoaDons
                        join b in _dbcontext.Users on a.IdUser equals b.Id
                        join c in _dbcontext.Vouchers on a.IdVoucher equals c.Id
                       
                        select new { a, b,c };
            var data = await query
           .Select(x => new HoaDonVM()
           {
               Id=x.a.Id,
               TenTK = x.b.TenTaiKhoan,
               TenVoucher = x.c.Ten,
               MaHD = x.a.MaHD,
               NgayTao = x.a.NgayTao,
               NgayNhan = x.a.NgayNhan,
               NgayThanhToan = x.a.NgayThanhToan,
               NgayShip = x.a.NgayShip,
               NguoiNhan = x.a.NguoiNhan,
               DiaChi = x.a.DiaChi,
               SDT = x.a.SDT,
               SoDiemSD = x.a.SoDiemSD,
               TienShip = x.a.TienShip,
               TongTien = x.a.TongTien,

               TrangThai = x.a.TrangThai,

           }
            ).ToListAsync();
            return data;
        }

        public async Task<HoaDonVM> GetHoaDonById(Guid id)
        {
            var hd = await _dbcontext.HoaDons.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (hd == null)
            {
                return null;
            }
            var hoadon = new HoaDonVM
            {
                    Id = hd.Id,
                    IdUser = hd.IdUser,
                    IdVoucher = hd.IdVoucher,
                    MaHD = hd.MaHD,
                    NgayTao = hd.NgayTao,
                    NgayNhan = hd.NgayNhan,
                    NgayThanhToan = hd.NgayThanhToan,
                    NgayShip = hd.NgayShip,
                    NguoiNhan = hd.NguoiNhan,
                    DiaChi = hd.DiaChi,
                    SDT = hd.SDT,
                    SoDiemSD = hd.SoDiemSD,
                    TienShip = hd.TienShip,
                    TongTien = hd.TongTien,

                    TrangThai = hd.TrangThai,
            };
            return hoadon;
        }
    }
}
