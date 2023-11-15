using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public Guid IdCV { get; set; }
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Họ Tên tối đa 25 ký tự và tối thiểu 3 ký tự")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Url trống")]
        public string Url { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Tên người dùng chỉ có thể chứa các chữ cái, số và dấu gạch dưới")]
        public string? TenTaiKhoan { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Mật khẩu phải dài ít nhất 8 ký tự và chứa ít nhất một chữ cái viết thường, một chữ cái viết hoa và một chữ số")]
        public string MatKhau { get; set; }
        [RegularExpression(@"^(\+[0-9]{1,2}\s?)?(\([0-9]{1,4}\))?\s?[0-9]{6,}$", ErrorMessage = "SĐT không hợp lệ")]
        public int SDT { get; set; }
        public int GioiTinh { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Số điểm phải là số")]
        public int SoDiem { get; set; }

        public int TrangThai { get; set; }

        //join
        
        public string ?ChucVu { get; set; }  
    }
}
