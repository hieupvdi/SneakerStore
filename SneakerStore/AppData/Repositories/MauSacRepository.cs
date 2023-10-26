using AppData.IRepositories;
using AppData.SneakerDbContext;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Repositories
{
    public class MauSacRepository: IMauSacRepository
    {
        private readonly SNDbcontext _shopDbContext;
        public MauSacRepository(SNDbcontext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<List<MauSac>> GetAll()
        {
            return await _shopDbContext.MauSacs
                    .Select(i => new MauSac()
                    {
                        Id = i.Id,
                        TenMauSac = i.TenMauSac
                      
                    }
                ).ToListAsync();
        }
        

        public async Task<MauSac> GetById(Guid id)
        {
            var mausac = await _shopDbContext.MauSacs.FindAsync(id);         
            return mausac;
        }

        public async Task<Guid> Edit(MauSac ms)
        {
            var mausac = await _shopDbContext.MauSacs.FindAsync(ms.Id);
            if (mausac == null) {
                throw new ($"Không thể tim thấy mauSac với Id:  {ms.Id}");
            }

            mausac.TenMauSac = ms.TenMauSac;           
            await _shopDbContext.SaveChangesAsync();
            return mausac.Id;
        }

        public async Task<Guid> Create(MauSac ms)
        {
            var mausac = new MauSac()
            {
                Id = Guid.NewGuid(),
                TenMauSac = ms.TenMauSac,
                
            };
            await _shopDbContext.MauSacs.AddAsync(mausac);
            await _shopDbContext.SaveChangesAsync();
            return mausac.Id;
        }

        public async Task<int> Delete(Guid id)
        {
            var mauSac = await _shopDbContext.MauSacs.FindAsync(id);
            if (mauSac == null)
            {
                throw new ($"Không thể tìm thấy 1 mauSac : {id}");
            }
            _shopDbContext.MauSacs.Remove(mauSac);
            return await _shopDbContext.SaveChangesAsync();

        }

     
    }
}
