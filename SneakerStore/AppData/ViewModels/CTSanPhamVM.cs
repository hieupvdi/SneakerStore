using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class CTSanPhamVM
    {
        public Guid Id { get; set; }
        [StringLength(150, ErrorMessage = "Mô ta tối đa 150 ký tự")]
        public string MoTa { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Gía Nhập phải là số")]
        public decimal Gianhap { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Gía Bán phải là số")]
        public decimal Giaban { get; set; }
        [StringLength(100, ErrorMessage = "Chất liệu tối đa 100 ký tự")]
        public string ChatLieu { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "số lượng tồn phải là số")]
        public int SoLuongTon { get; set; }
        [StringLength(100, ErrorMessage = "Nhà sản xuất tối đa 100 ký tự")]
        public string NhaSanXuat { get; set; }
        public int TrangThai { get; set; }
        public Guid IdSP { get; set; }
        public Guid IdSize { get; set; }
        public Guid IdMauSac { get; set; }
        public Guid IdDanhMuc { get; set; }
        public Guid IdDeGiay { get; set; }
        public Guid IdGiamGia { get; set; }
        //thuoc tính join
        public string ?TenSP { get; set; }
        public int? SizeNumber { get; set; }
        public string? Mau { get; set; }
        public string? TenDanhMuc { get; set; }
        public string? DeGiay { get; set; }
        public int? GiamGia { get; set; }




    }
}
