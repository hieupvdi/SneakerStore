using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public  class DeGiay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<CTSanPham> CTSanPhams { get; set; }
    }
}
