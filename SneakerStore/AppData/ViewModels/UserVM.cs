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
        public string ?Url { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tên tài khoản không thể trống.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Tên tài khoản phải chứa ít nhất một chữ thường, một chữ hoa và một số")]
        public string? TenTaiKhoan { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{5,}$", ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ thường, một chữ hoa, một số. Độ dài tối thiểu là 5 ký tự.")]

        public string MatKhau { get; set; }
        [RegularExpression(@"^(\+[0-9]{1,2}\s?)?(\([0-9]{1,4}\))?\s?[0-9]{6,}$", ErrorMessage = "SĐT không hợp lệ")]
        public string SDT { get; set; }
        public int GioiTinh { get; set; }
        public int TrangThai { get; set; }

        //join
        
        public string ?ChucVu { get; set; }  
    }
}
