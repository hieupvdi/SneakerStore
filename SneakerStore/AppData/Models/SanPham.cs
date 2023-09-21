using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SanPham
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public string ChatLieu { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaSanXuat { get; set; }
        public int TrangThai { get; set; }
        public Guid IDKichCo { get; set; }  
        public Guid IDMauSac { get; set; }
        public Guid IDLoaiSanPham { get; set; }
        public Guid IDAnhSanPham { get; set; }
        public Guid IDGiamGia { get; set; }
        public virtual KichCo? KichCo { get; set; }
        public virtual LoaiSanPham? LoaiSanPham { get; set; }
        public virtual MauSac? MauSac { get; set; }
        public virtual AnhSanPham? AnhSanPham { get; set; }
        public virtual GiamGia? GiamGia { get; set; }
    }
}
