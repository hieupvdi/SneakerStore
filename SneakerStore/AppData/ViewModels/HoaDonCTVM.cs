using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class HoaDonCTVM
    {
        public Guid Id { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdCTSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int TrangThai { get; set; }
        //THUOC TINH JOIN

        public string? MaHD { get; set; }
        public string? TenSP { get; set; }
    }
}
