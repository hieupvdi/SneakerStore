using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class CTSanPham
    {
        public Guid Id { get; set; }
        public string MoTa { get; set; }
        public decimal Gianhap { get; set; }
        public decimal Giaban { get; set; }
        public string ChatLieu { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaSanXuat { get; set; }
        public int TrangThai { get; set; }
        public Guid IdSP { get; set; }  
        public Guid IdKichCo { get; set; }  
        public Guid IdMauSac { get; set; }
        public Guid IdLoaiSanPham { get; set; }
        public Guid IdDeGiay { get; set; }
        public Guid IdGiamGia { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual KichCo? KichCo { get; set; }
        public virtual LoaiSanPham? LoaiSanPham { get; set; }
        public virtual MauSac? MauSac { get; set; }
        public virtual DeGiay? DeGiay { get; set; }
        public virtual GiamGia? GiamGia { get; set; }

        public virtual ICollection<AnhSanPham> AnhSanPham { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiet { get; set; }
        public ICollection<GioHangChiTiet> GioHangChiTiet { get; set; }

    }
}
