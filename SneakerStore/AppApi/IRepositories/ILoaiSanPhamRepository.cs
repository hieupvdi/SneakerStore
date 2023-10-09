using AppData.Models;

namespace AppApi.IRepositories
{
    public interface ILoaiSanPhamRepository
    {
        public Task<List<LoaiSanPham>> GetAll();
        public Task<Guid> Create(LoaiSanPham ls);
        public Task<Guid> Edit(LoaiSanPham ls);
        public Task<int> Delete(Guid id);
        public Task<LoaiSanPham> GetById(Guid id);
    }
}
