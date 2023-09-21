using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class HoaDonChiTiet
    {
        public Guid IDHoaDon { get; set; }
        public Guid IDSanPham { get; set; }
        public string NguoiNhan { get; set; }
        public string SDTNhan { get; set; }
        public decimal Gia { get; set; }
        public int TrangThai { get; set; }
        public virtual HoaDon? HoaDon { get; set; }
        public virtual SanPham? SanPham { get; set; }

    }
}
