using AppApi.IRepositories;
using AppData.SneakerDbContext;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Repositories
{
    public class KichCoRepository : IKichCoRepository
    {
        private readonly SNDbcontext _shopDbContext;
        public KichCoRepository(SNDbcontext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<Guid> Create(KichCo kc)
        {
            var kichco = new KichCo()
            {
                Id = Guid.NewGuid(),
                Size = kc.Size,

            };
            await _shopDbContext.KichCos.AddAsync(kichco);
            await _shopDbContext.SaveChangesAsync();
            return kichco.Id;
        }

        public async Task<int> Delete(Guid id)
        {
            var kichco = await _shopDbContext.KichCos.FindAsync(id);
            if (kichco == null)
            {
                throw new($"Không thể tìm thấy 1 kichco : {id}");
            }
            _shopDbContext.KichCos.Remove(kichco);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<Guid> Edit(KichCo kc)
        {
            var kichco = await _shopDbContext.KichCos.FindAsync(kc.Id);
            if (kichco == null)
            {
                throw new($"Không thể tim thấy Kichco với Id:  {kc.Id}");
            }

            kichco.Size = kc.Size;
            await _shopDbContext.SaveChangesAsync();
            return kichco.Id;
        }

        public async Task<List<KichCo>> GetAll()
        {
            return await _shopDbContext.KichCos
                   .Select(i => new KichCo()
                   {
                       Id = i.Id,
                       Size = i.Size

                   }
               ).ToListAsync();
        }

        public async Task<KichCo> GetById(Guid id)
        {
            var kichco = await _shopDbContext.KichCos.FindAsync(id);
            return kichco;
        }
    }
}
