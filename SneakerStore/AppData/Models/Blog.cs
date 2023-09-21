using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Blog
    {
        public Guid Id { get; set; }

        public string? TieuDe { get; set; }

        public string? NoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public int TrangThai { get; set; }  
    }
}
