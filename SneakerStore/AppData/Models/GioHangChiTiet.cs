using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHangChiTiet
    {
        public Guid ID { get; set; }
        public Guid IDUser { get; set; }
        public int  SoLuong { get; set; }
        public int TrangThai { get; set; }
        public decimal GiaTien { get; set; }
        public Guid IDSanPham { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual GioHang? GioHang { get; set; }
        
    }
}
