using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class LoaiSanPhamVM
    {
        public Guid Id { get; set; }
        public string TenLoaiSanPham { get; set; }
        public int TrangThai { get; set; }
    }
}
