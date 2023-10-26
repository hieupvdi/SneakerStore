using AppData.Models;

namespace AppData.IRepositories
{
    public interface IMauSacRepository
    {
        public Task<List<MauSac>> GetAll();
        public Task<Guid> Create(MauSac ms);
        public Task<Guid> Edit(MauSac ms);
        public Task<int> Delete(Guid id);
        public Task<MauSac> GetById(Guid id);
    }
}
