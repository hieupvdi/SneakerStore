using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class KichCo
    {
        public Guid Id { get; set; }
        public double Size { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<CTSanPham> CTSanPham { get; set; }
    }
}
