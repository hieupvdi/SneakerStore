using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GiamGia
    {
        public Guid ID { get; set; }
        public string TenMaGiamGia { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int PhamTram { get; set; }
        public int TrangThai { get; set; }
        public string MoTa { get; set; }
    }
}
