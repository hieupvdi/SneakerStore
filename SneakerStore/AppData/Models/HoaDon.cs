using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class HoaDon
    {
        public Guid ID { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int TrangThai { get; set; }
        public Guid IDUser { get; set; }
        public virtual ApplicationUser? User { get; set; }

    }
}
