using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class CTSanPhamVM
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
        //thuoc tính join
        public string TenSP { get; set; }
        public int Size { get; set; }
        public string Mau { get; set; }
        public string Loaisp { get; set; }
        public string De { get; set; }
        public string GiamGia { get; set; }




    }
}
