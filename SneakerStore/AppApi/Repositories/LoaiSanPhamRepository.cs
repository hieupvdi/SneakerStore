using AppApi.IRepositories;
using AppApi.SneakerDbContext;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Repositories
{
    public class LoaiSanPhamRepository : ILoaiSanPhamRepository
    {
        private readonly SNDbcontext _shopDbContext;
        public LoaiSanPhamRepository(SNDbcontext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<Guid> Create(LoaiSanPham ls)
        {
            var loaisp = new LoaiSanPham()
            {
                ID = Guid.NewGuid(),
                TenLoaiSanPham = ls.TenLoaiSanPham,

            };
            await _shopDbContext.LoaiSanPhams.AddAsync(loaisp);
            await _shopDbContext.SaveChangesAsync();
            return loaisp.ID;
        }

        public async Task<int> Delete(Guid id)
        {
            var loaisp = await _shopDbContext.LoaiSanPhams.FindAsync(id);
            if (loaisp == null)
            {
                throw new($"Không thể tìm thấy 1 loai sp : {id}");
            }
            _shopDbContext.LoaiSanPhams.Remove(loaisp);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<Guid> Edit(LoaiSanPham ls)
        {
            var loaisp = await _shopDbContext.LoaiSanPhams.FindAsync(ls.ID);
            if (loaisp == null)
            {
                throw new($"Không thể tim thấy loai sp với Id:  {ls.ID}");
            }

            loaisp.TenLoaiSanPham = ls.TenLoaiSanPham;
            await _shopDbContext.SaveChangesAsync();
            return loaisp.ID;
        }

        public async Task<List<LoaiSanPham>> GetAll()
        {
            return await _shopDbContext.LoaiSanPhams
                    .Select(i => new LoaiSanPham()
                    {
                        ID = i.ID,
                        TenLoaiSanPham = i.TenLoaiSanPham

                    }
                ).ToListAsync();
        }

        public async Task<LoaiSanPham> GetById(Guid id)
        {
            var loaisp = await _shopDbContext.LoaiSanPhams.FindAsync(id);
            return loaisp;
        }
    }
}
