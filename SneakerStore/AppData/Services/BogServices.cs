using AppData.IServices;
using AppData.Models;
using AppData.SneakerDbContext;
using AppData.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
    public class BogServices: IBogServices
    {
        public readonly SNDbcontext _dbcontext;
        public BogServices()
        {
            _dbcontext = new SNDbcontext();
        }
        public async Task<bool> CreateBog(BogVM obj)
        {
            try
            {
                var bog = new Bog
                {

                    Id = Guid.NewGuid(),
                    IdUser = obj.IdUser,
                    TieuDe = obj.TieuDe,
                    NoiDung = obj.NoiDung,
                    UrlAnh = obj.UrlAnh,
                    NgayTao = obj.NgayTao,
                   
                    TrangThai = obj.TrangThai,
                };

                await _dbcontext.AddAsync(bog);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteBog(Guid id)
        {
            try
            {
                // Kiểm tra xem KhachHang có tồn tại không
                var bog = await _dbcontext.Bogs.FirstOrDefaultAsync(c => c.Id == id);
                if (bog != null)
                {
                    bog.TrangThai = 0;
                    _dbcontext.Update(bog);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> EditBog(BogVM obj)
        {
            try
            {
                // Kiểm tra xem khachhang có tồn tại không
                var bog = await _dbcontext.Bogs.FirstOrDefaultAsync(c => c.Id == obj.Id);

                if (bog != null)
                {


                    bog.IdUser = obj.IdUser;
                    bog.TieuDe = obj.TieuDe;
                    bog.NoiDung = obj.NoiDung;
                    bog.UrlAnh = obj.UrlAnh;
                    bog.NgayTao = obj.NgayTao;
                    bog.TrangThai = obj.TrangThai;

                    _dbcontext.Update(bog);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<List<BogVM>> GetBogAll()
        {
            var query = from a in _dbcontext.Bogs
                        join b in _dbcontext.Users on a.IdUser equals b.Id
                        select new { a, b };
            var data = await query
           .Select(x => new BogVM()
           {
               Id = x.a.Id,
               NguoiDang = x.b.TenTaiKhoan,
               TieuDe = x.a.TieuDe,
               NoiDung = x.a.NoiDung,
               UrlAnh = x.a.UrlAnh,
               NgayTao = x.a.NgayTao,
               TrangThai = x.a.TrangThai,

        }
            ).ToListAsync();
            return data;
        }

        public async Task<BogVM> GetBogById(Guid id)
        {
            var bog = await _dbcontext.Bogs.AsQueryable().FirstOrDefaultAsync(c => c.Id == id && c.TrangThai != 0);

            if (bog == null)
            {
                return null;
            }
            var bo = new BogVM
            {
                Id = bog.Id,
                IdUser = bog.IdUser,
                TieuDe = bog.TieuDe,
                NoiDung = bog.NoiDung,
                UrlAnh = bog.UrlAnh,
                NgayTao = bog.NgayTao,
                TrangThai = bog.TrangThai,
            };

            return bo;
        }
    }
}
