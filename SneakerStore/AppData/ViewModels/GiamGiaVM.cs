using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class GiamGiaVM
    {
        public Guid Id { get; set; }
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Tên giảm giá tối đa 25 ký tự và tối thiểu 5 ký tự")]
        public string TenMaGiamGia { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Phần trăm phải là số")]
        public int PhamTram { get; set; }
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Mô ta tối đa 150 ký tự và tối thiểu 5 ký tự")]
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
    }
}
