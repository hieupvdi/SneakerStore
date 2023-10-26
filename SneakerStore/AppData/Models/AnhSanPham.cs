using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class AnhSanPham
    {
        public Guid Id { get; set; }
        public Guid IdCTSP { get; set; }
        public string URlAnh { get; set; }
        public int TrangThai { get; set; }
        public virtual CTSanPham? CTSanPhams { get; set; }
    }
}
