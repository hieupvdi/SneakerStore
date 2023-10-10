using AppData.Models;

namespace AppApi.IRepositories
{
    public interface IGiamGiaRepository
    {
        public Task<List<GiamGia>> GetAll();
        public Task<Guid> Create(GiamGia gg);
        public Task<Guid> Edit(GiamGia gg);
        public Task<int> Delete(Guid id);
        public Task<GiamGia> GetById(Guid id);
    }
}
