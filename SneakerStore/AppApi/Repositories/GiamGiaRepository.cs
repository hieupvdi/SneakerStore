using AppApi.IRepositories;
using AppApi.SneakerDbContext;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Repositories
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
        private readonly SNDbcontext _shopDbContext;
        public GiamGiaRepository(SNDbcontext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<Guid> Create(GiamGia gg)
        {
            var giamgia = new GiamGia()
            {
                ID = Guid.NewGuid(),
                TenMaGiamGia = gg.TenMaGiamGia,
                NgayBatDau=gg.NgayBatDau,
                NgayKetThuc=gg.NgayKetThuc,
                PhamTram=gg.PhamTram,
                TrangThai=gg.TrangThai,
                MoTa=gg.MoTa,

            };
            await _shopDbContext.GiamGias.AddAsync(giamgia);
            await _shopDbContext.SaveChangesAsync();
            return giamgia.ID;
        }

        public async Task<int> Delete(Guid id)
        {
            var giamgia = await _shopDbContext.GiamGias.FindAsync(id);
            if (giamgia == null)
            {
                throw new($"Không thể tìm thấy giam gia : {id}");
            }
            _shopDbContext.GiamGias.Remove(giamgia);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<Guid> Edit(GiamGia gg)
        {
            var giamgia = await _shopDbContext.GiamGias.FindAsync(gg.ID);
            if (giamgia == null)
            {
                throw new($"Không thể tim thấy giamgia với Id:  {gg.ID}");
            }

            giamgia.TenMaGiamGia = gg.TenMaGiamGia;
            giamgia.NgayBatDau = gg.NgayBatDau;
            giamgia.NgayKetThuc = gg.NgayKetThuc;
            giamgia.PhamTram = gg.PhamTram;
            giamgia.TrangThai = gg.TrangThai;
            giamgia.MoTa = gg.MoTa;
            await _shopDbContext.SaveChangesAsync();
            return giamgia.ID;
        }

        public async Task<List<GiamGia>> GetAll()
        {
            return await _shopDbContext.GiamGias
                   .Select(i => new GiamGia()
                   {
                       ID = i.ID,
                       TenMaGiamGia = i.TenMaGiamGia,
                       NgayBatDau = i.NgayBatDau,
                       NgayKetThuc = i.NgayKetThuc,
                       PhamTram = i.PhamTram,
                       TrangThai = i.TrangThai,
                       MoTa = i.MoTa,

        }
               ).ToListAsync();
        }

        public async Task<GiamGia> GetById(Guid id)
        {
            var giamgia = await _shopDbContext.GiamGias.FindAsync(id);
            return giamgia;
        }
    }
}
