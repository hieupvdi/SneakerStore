using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AppData.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public string? DiaChi { get; set; }
        public string? UrlAnh { get; set; }
        public int TrangThai { get; set; }
        public GioHang? GioHang { get; set; }
    }
}
