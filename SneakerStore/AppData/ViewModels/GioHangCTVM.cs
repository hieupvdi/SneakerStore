using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class GioHangCTVM
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public Guid IdCTSP { get; set; }
        public int TrangThai { get; set; }


        //thuộc tính join
        public  string TenTK { get; set; }
        public string TenSP { get; set;}
    }
}
