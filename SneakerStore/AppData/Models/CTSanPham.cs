using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid IdSP { get; set; }  
        public Guid IdSize { get; set; }  
        public Guid IdMauSac { get; set; }
        public Guid IdDanhMuc { get; set; }
        public Guid IdDeGiay { get; set; }
        public Guid IdGiamGia { get; set; }
        public int TrangThai { get; set; }

        public virtual SanPham? SanPham { get; set; }
        public virtual Size? Size { get; set; }
        public virtual DanhMuc? DanhMuc { get; set; }
        public virtual MauSac? MauSac { get; set; }
        public virtual DeGiay? DeGiay { get; set; }
        public virtual GiamGia? GiamGia { get; set; }

        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }
        public virtual ICollection<HoaDonCT> HoaDonCTs { get; set; }
        public ICollection<GioHangCT> GioHangCTs { get; set; }

    }
}
