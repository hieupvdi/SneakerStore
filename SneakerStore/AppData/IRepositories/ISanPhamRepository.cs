using AppData.Models;

namespace AppData.IRepositories
{
    public interface ISanPhamRepository
    {
        public Task<List<CTSanPham>> GetAll();
        public Task<Guid> Create(CTSanPham sp);
        public Task<Guid> Edit(CTSanPham sp);
        public Task<int> Delete(Guid id);
        public Task<CTSanPham> GetById(Guid id);
    }
}
