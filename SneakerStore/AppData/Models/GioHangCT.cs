using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHangCT
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public int  SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public Guid IdCTSP { get; set; }
        public int TrangThai { get; set; }

        public virtual CTSanPham? CTSanPham { get; set; }
        public virtual GioHang? GioHang { get; set; }
        
    }
}
