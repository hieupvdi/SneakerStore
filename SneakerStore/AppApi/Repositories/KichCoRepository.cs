using AppApi.IRepositories;
using AppApi.SneakerDbContext;
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
                ID = Guid.NewGuid(),
                Size = kc.Size,

            };
            await _shopDbContext.KichCos.AddAsync(kichco);
            await _shopDbContext.SaveChangesAsync();
            return kichco.ID;
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

        public Task<Guid> Edit(KichCo kc)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KichCo>> GetAll()
        {
            return await _shopDbContext.KichCos
                   .Select(i => new KichCo()
                   {
                       ID = i.ID,
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
