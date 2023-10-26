using AppData.IRepositories;
using AppData.SneakerDbContext;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly SNDbcontext _shopDbContext;
        public SanPhamRepository(SNDbcontext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<Guid> Create(CTSanPham sp)
        {
            //var sanpham = new CTSanPham()
            //{
            //    Id = Guid.NewGuid(),
            //    Ten= sp.Ten,
            //    MoTa = sp.MoTa,
            //    Gia = sp.Gia,
            //    ChatLieu = sp.ChatLieu,
            //    SoLuongTon = sp.SoLuongTon,
            //    NhaSanXuat = sp.NhaSanXuat,
            //    TrangThai = sp.TrangThai,
            //    IDKichCo = sp.IDKichCo,
            //    IDMauSac = sp.IDMauSac,
            //    IDLoaiSanPham = sp.IDLoaiSanPham,
            //    IDAnhSanPham = sp.IDAnhSanPham,
            //    IDGiamGia = sp.IDGiamGia,

            //};
            //await _shopDbContext.SanPhams.AddAsync(sanpham);
            //await _shopDbContext.SaveChangesAsync();
            //return sanpham.Id;
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Guid id)
        {
            var sanpham = await _shopDbContext.SanPhams.FindAsync(id);
            if (sanpham == null)
            {
                throw new($"Không thể tìm thấy 1 anh sp : {id}");
            }
            _shopDbContext.SanPhams.Remove(sanpham);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<Guid> Edit(CTSanPham sp)
        {
            //var sanpham = await _shopDbContext.SanPhams.FindAsync(sp.Id);
            //if (sanpham == null)
            //{
            //    throw new($"Không thể tim thấy loai sp với Id:  {sanpham.Id}");
            //}


            //sanpham.Ten = sp.Ten;
            //sanpham.MoTa = sp.MoTa;
            //sanpham.Gia = sp.Gia;
            //sanpham.ChatLieu = sp.ChatLieu;
            //sanpham.SoLuongTon = sp.SoLuongTon;
            //sanpham.NhaSanXuat = sp.NhaSanXuat;
            //sanpham.TrangThai = sp.TrangThai;
            //sanpham.IDKichCo = sp.IDKichCo;
            //sanpham.IDMauSac = sp.IDMauSac;
            //sanpham.IDLoaiSanPham = sp.IDLoaiSanPham;
            //sanpham.IDAnhSanPham = sp.IDAnhSanPham;
            //sanpham.IDGiamGia = sp.IDGiamGia;
            //await _shopDbContext.SaveChangesAsync();
            //return sanpham.ID;
            throw new NotImplementedException();
        }

        public async Task<List<CTSanPham>> GetAll()
        {

            //var query = from a in _shopDbContext.SanPhams
            //            join b in _shopDbContext.KichCos on a.IDKichCo equals b.ID
            //            join c in _shopDbContext.MauSacs on a.IDMauSac equals c.ID
            //            join d in _shopDbContext.LoaiSanPhams on a.IDLoaiSanPham equals d.ID
            //            join e in _shopDbContext.AnhSanPhams on a.IDAnhSanPham equals e.ID
            //            join g in _shopDbContext.GiamGias on a.IDGiamGia equals g.ID
            //            select new { a, b, c, d, e, g };
            // var data = await query
            //.Select(x => new CTSanPham()
            //{
            //    ID = x.a.ID,
            //    Ten = x.a.Ten,
            //    MoTa = x.a.MoTa,
            //    Gia = x.a.Gia,
            //    ChatLieu = x.a.ChatLieu,
            //    SoLuongTon = x.a.SoLuongTon,
            //    NhaSanXuat = x.a.NhaSanXuat,
            //    TrangThai = x.a.TrangThai,
            //    IDKichCo = x.b.ID,
            //    IDMauSac = x.c.ID,
            //    IDLoaiSanPham = x.d.ID,
            //    IDAnhSanPham = x.e.ID,
            //    IDGiamGia = x.g.ID,
            //}
            // ).ToListAsync();
            // return data;

            throw new NotImplementedException();
        }

        public async Task<CTSanPham> GetById(Guid id)
        {
            var sp = await _shopDbContext.SanPhams.FindAsync(id);
            return sp;
        }
    }
}
