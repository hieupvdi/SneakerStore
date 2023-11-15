using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int PhanTram { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
