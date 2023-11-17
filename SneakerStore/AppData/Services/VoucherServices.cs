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
    public class VoucherServices: IVoucherServices
    {
        public readonly SNDbcontext _dbcontext;
        public VoucherServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateVoucher(VoucherVM obj)
        {
            try
            {
                var V = new Voucher
                {

                    Id = Guid.NewGuid(),
                    Ten = obj.Ten,
                    DieuKien=obj.DieuKien,
                    PhanTram =obj.PhanTram, 
                    NgayBatDau=obj.NgayBatDau,
                    NgayKetThuc=obj.NgayKetThuc,
                    SoLuong=obj.SoLuong,
                    MoTa=obj.MoTa,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(V);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteVoucher(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var v = await _dbcontext.Vouchers.FirstOrDefaultAsync(c => c.Id == id);
                if (v != null)
                {
                    v.TrangThai = 0;
                    _dbcontext.Update(v);
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

        public async Task<bool> EditVoucher(VoucherVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var v = await _dbcontext.Vouchers.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (v != null)
                {
                    v.Ten = obj.Ten;
                    v.DieuKien = obj.DieuKien;         
                    v.PhanTram = obj.PhanTram;
                    v.NgayBatDau = obj.NgayBatDau;
                    v.NgayKetThuc = obj.NgayKetThuc;
                    v.SoLuong = obj.SoLuong;
                    v.MoTa = obj.MoTa;
                    v.TrangThai = obj.TrangThai;

                    _dbcontext.Update(v);
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

        public async Task<List<VoucherVM>> GetVoucherAll()
        {


            var query = from c in _dbcontext.Vouchers
                        select new VoucherVM
                        {
                            Id = c.Id,
                            Ten = c.Ten,
                            DieuKien = c.DieuKien,

                            PhanTram = c.PhanTram,
                            NgayBatDau = c.NgayBatDau,
                            NgayKetThuc = c.NgayKetThuc,
                            SoLuong = c.SoLuong,
                            MoTa = c.MoTa,
                            TrangThai = c.TrangThai,
                        };

            var result = await query.ToListAsync();

            return result;

        }

        public async Task<VoucherVM> GetVoucherById(Guid id)
        {
            var v = await _dbcontext.Vouchers.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (v == null)
            {
                return null;
            }
            var vo = new VoucherVM
            {
                Id = v.Id,
                Ten = v.Ten,
                DieuKien = v.DieuKien,
                PhanTram = v.PhanTram,
                NgayBatDau = v.NgayBatDau,
                NgayKetThuc = v.NgayKetThuc,
                SoLuong = v.SoLuong,
                MoTa = v.MoTa,
                TrangThai = v.TrangThai,
            };

            return vo;
        }
    }
}
