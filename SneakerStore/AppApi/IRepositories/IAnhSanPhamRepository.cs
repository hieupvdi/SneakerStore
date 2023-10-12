using AppData.Models;

namespace AppApi.IRepositories
{
    public interface IAnhSanPhamRepository
    {
        public Task<List<AnhSanPham>> GetAll();
        public Task<Guid> Create(AnhSanPham asp);
        public Task<Guid> Edit(AnhSanPham asp);
        public Task<int> Delete(Guid id);
        public Task<AnhSanPham> GetById(Guid id);
    }
}
