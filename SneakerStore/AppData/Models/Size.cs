using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public int SizeNumber { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<CTSanPham> CTSanPhams { get; set; }
    }
}
