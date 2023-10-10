using AppApi.IRepositories;
using AppApi.SneakerDbContext;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Repositories
{
    public class AnhSanPhamRepository : IAnhSanPhamRepository
    {
        private readonly SNDbcontext _shopDbContext;
        public AnhSanPhamRepository(SNDbcontext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<Guid> Create(AnhSanPham asp)
        {
            var sp = new AnhSanPham()
            {
                ID = Guid.NewGuid(),
                URlAnh = asp.URlAnh,

            };
            await _shopDbContext.AnhSanPhams.AddAsync(asp);
            await _shopDbContext.SaveChangesAsync();
            return sp.ID;
        }

        public async Task<int> Delete(Guid id)
        {
            var sp = await _shopDbContext.AnhSanPhams.FindAsync(id);
            if (sp == null)
            {
                throw new($"Không thể tìm thấy 1 anh sp : {id}");
            }
            _shopDbContext.AnhSanPhams.Remove(sp);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<Guid> Edit(AnhSanPham asp)
        {
            var sp = await _shopDbContext.AnhSanPhams.FindAsync(asp.ID);
            if (sp == null)
            {
                throw new($"Không thể tim thấy loai sp với Id:  {sp.ID}");
            }

            sp.URlAnh = asp.URlAnh;
            await _shopDbContext.SaveChangesAsync();
            return sp.ID;
        }

        public async Task<List<AnhSanPham>> GetAll()
        {
            return await _shopDbContext.AnhSanPhams
                  .Select(i => new AnhSanPham()
                  {
                      ID = i.ID,
                      URlAnh = i.URlAnh

                  }
              ).ToListAsync();
        }

        public async Task<AnhSanPham> GetById(Guid id)
        {
            var sp = await _shopDbContext.AnhSanPhams.FindAsync(id);
            return sp;
        }
    }
}
