using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdCTSP { get; set; }
        public int SoLuong { get; set; }    
        public decimal DonGia { get; set; }
        public virtual HoaDon? HoaDons { get; set; }
        public virtual CTSanPham? CTSanPhams { get; set; }

    }
}
