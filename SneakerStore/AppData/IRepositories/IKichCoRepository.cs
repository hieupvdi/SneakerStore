using AppData.Models;

namespace AppData.IRepositories
{
    public interface IKichCoRepository
    {
        public Task<List<KichCo>> GetAll();
        public Task<Guid> Create(KichCo kc);
        public Task<Guid> Edit(KichCo kc);
        public Task<int> Delete(Guid id);
        public Task<KichCo> GetById(Guid id);
    }
}
