using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Voucher
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public decimal DieuKien { get; set; }
        public decimal SoTienGiam { get; set; }
        public DateTime NgayApDung { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
