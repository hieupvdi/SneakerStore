using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class BlogVM
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        [StringLength(100, ErrorMessage = "Tiêu đề tối đa 100 ký tự")]
        public string TieuDe { get; set; }
        [MinLength(150, ErrorMessage = "Nội dung tối thiểu 150 ký tự")]
        public string NoiDung { get; set; }
        [Required(ErrorMessage = "Url trống")]
        public string UrlAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
        //join
        public string? NguoiDang { get; set; }

    }
}
