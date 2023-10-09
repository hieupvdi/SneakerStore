using AppData.Models;

namespace AppApi.IRepositories
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
