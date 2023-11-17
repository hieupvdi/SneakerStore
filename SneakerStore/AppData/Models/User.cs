using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid IdCV { get; set; }
        public string HoTen { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int SDT { get; set; }
        public int GioiTinh { get; set; }
        public int TrangThai { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
        public virtual GioHang? GioHang { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<DiaChi> DiaChis { get; set; }

    }
}
