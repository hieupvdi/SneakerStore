using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class HoaDonVM
    {
        public Guid Id { get; set; }
        public Guid? IdUser { get; set; }
        public Guid? IdVoucher { get; set; }
        public string MaHD { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public DateTime? NgayShip { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public int SoDiemSD { get; set; }
        public decimal TienShip { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThai { get; set; }

    }
}
