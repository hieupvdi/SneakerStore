﻿using AppData.IServices;
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
    public class CTSanPhamServices: ICTSanPhamServices
    {
        public readonly SNDbcontext _dbcontext;
        public CTSanPhamServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateCTSanPham(CTSanPhamVM obj)
        {
            try
            {
                var ctsp = new CTSanPham
                {

                    Id = Guid.NewGuid(),
                    MoTa =obj.MoTa,
                    Gianhap =obj.Gianhap,
                    Giaban =obj.Giaban,
                    ChatLieu =obj.ChatLieu,
                    SoLuongTon=obj.SoLuongTon,
                    NhaSanXuat =obj.NhaSanXuat,
                    IdSP =obj.IdSP,
                    IdKichCo =obj.IdKichCo,
                    IdMauSac=obj.IdMauSac, 
                    IdLoaiSanPham =obj.IdLoaiSanPham,
                    IdDeGiay =obj.IdDeGiay,
                    IdGiamGia =obj.IdGiamGia,
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(ctsp);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteCTSanPham(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var ctsp = await _dbcontext.CTSanPhams.FirstOrDefaultAsync(c => c.Id == id);
                if (ctsp != null)
                {
                    ctsp.TrangThai = 0;
                    _dbcontext.Update(ctsp);
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

        public async Task<bool> EditCTSanPham(CTSanPhamVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var ctsp = await _dbcontext.CTSanPhams.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (ctsp != null)
                {
                    ctsp.MoTa = obj.MoTa;
                    ctsp.Gianhap = obj.Gianhap;
                    ctsp.Giaban = obj.Giaban;
                    ctsp.ChatLieu = obj.ChatLieu;
                    ctsp.SoLuongTon = obj.SoLuongTon;
                    ctsp.NhaSanXuat = obj.NhaSanXuat;
                    ctsp.IdSP = obj.IdSP;
                    ctsp.IdKichCo = obj.IdKichCo;
                    ctsp.IdMauSac = obj.IdMauSac;
                    ctsp.IdLoaiSanPham = obj.IdLoaiSanPham;
                    ctsp.IdDeGiay = obj.IdDeGiay;
                    ctsp.IdGiamGia = obj.IdGiamGia;
                    ctsp.TrangThai = obj.TrangThai;

                    _dbcontext.Update(ctsp);
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

        public async Task<List<CTSanPhamVM>> GetCTSanPhamAll()
        {
            var query = from a in _dbcontext.CTSanPhams
                        join b in _dbcontext.SanPhams on a.IdSP equals b.Id
                        join c in _dbcontext.KichCos on a.IdKichCo equals c.Id
                        join d in _dbcontext.MauSacs on a.IdMauSac equals d.Id
                        join f in _dbcontext.LoaiSanPhams on a.IdLoaiSanPham equals f.Id
                        join g in _dbcontext.DeGiays on a.IdDeGiay equals g.Id
                        join h in _dbcontext.GiamGias on a.IdGiamGia equals h.Id
                       
                        select new { a, b,c,d,f,g,h };
            var data = await query
           .Select(x => new CTSanPhamVM()
           {
               Id = x.a.Id,
               MoTa = x.a.MoTa,
               Gianhap = x.a.Gianhap,
               Giaban = x.a.Giaban,
               ChatLieu = x.a.ChatLieu,
               SoLuongTon = x.a.SoLuongTon,
               NhaSanXuat = x.a.NhaSanXuat,
               TenSP = x.b.SanPham.TenSP,
               Size = x.c.Size,
               Mau = x.d.TenMauSac,
               Loaisp = x.f.TenLoaiSanPham,
               De = x.g.Name,
               GiamGia = x.h.TenMaGiamGia,
               TrangThai = x.a.TrangThai,
           }
            ).ToListAsync();
            return data;
        }

        public async Task<CTSanPhamVM> GetCTSanPhamById(Guid id)
        {
            var ctsp = await _dbcontext.CTSanPhams.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai !=0);

            if (ctsp == null)
            {
                return null;
            }
            var sp = new CTSanPhamVM
            {
                Id = ctsp.Id,
                MoTa = ctsp.MoTa,
                Gianhap = ctsp.Gianhap,
                Giaban = ctsp.Giaban,
                ChatLieu = ctsp.ChatLieu,
                SoLuongTon = ctsp.SoLuongTon,
                NhaSanXuat = ctsp.NhaSanXuat,
                IdSP = ctsp.IdSP,
                IdKichCo = ctsp.IdKichCo,
                IdMauSac = ctsp.IdMauSac,
                IdLoaiSanPham = ctsp.IdLoaiSanPham,
                IdDeGiay = ctsp.IdDeGiay,
                IdGiamGia = ctsp.IdGiamGia,
                TrangThai = ctsp.TrangThai,
            };

            return sp;
        }

       
    }
}
