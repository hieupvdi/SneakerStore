using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class PhuongThucThanhToanCT
    {
        public Guid Id { get; set; }    
        public decimal SoTien { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdPTTT { get; set; }
        public int TrangThai { get; set; }
        public virtual HoaDon? HoaDons { get; set; }
        public virtual PhuongThucThanhToan? PhuongThucThanhToans { get; set; }
     
    }
}
