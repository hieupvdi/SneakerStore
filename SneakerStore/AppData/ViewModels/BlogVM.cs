using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class BlogVM
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string UrlAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
        //join
        public string? NguoiDang { get; set; }

    }
}
