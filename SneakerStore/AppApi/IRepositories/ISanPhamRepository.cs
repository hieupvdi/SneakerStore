using AppData.Models;

namespace AppApi.IRepositories
{
    public interface ISanPhamRepository
    {
        public Task<List<SanPham>> GetAll();
        public Task<Guid> Create(SanPham sp);
        public Task<Guid> Edit(SanPham sp);
        public Task<int> Delete(Guid id);
        public Task<SanPham> GetById(Guid id);
    }
}
