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
        public virtual SanPham? SanPhams { get; set; }
        public virtual KichCo? KichCos { get; set; }
        public virtual LoaiSanPham? LoaiSanPhams { get; set; }
        public virtual MauSac? MauSacs { get; set; }
        public virtual DeGiay? DeGiays { get; set; }
        public virtual GiamGia? GiamGias { get; set; }

        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }

    }
}
