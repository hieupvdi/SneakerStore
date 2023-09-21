using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class DiaChi
    {
        public Guid Id { get; set; }

        public Guid IDUser { get; set; }

        public string? ThanhPho { get; set; }

        public string? QuanHuyen { get; set; }

        public string? XaPhuong { get; set; }   
        public string? MoTa { get; set; }

        public int TrangThai { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
