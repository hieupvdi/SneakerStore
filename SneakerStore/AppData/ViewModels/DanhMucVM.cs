using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class DanhMucVM
    {
        public Guid Id { get; set; }
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Danh Mục tối đa 25 ký tự và tối thiểu 3 ký tự")]
        public string Ten { get; set; }
        public int TrangThai { get; set; }
    }
}
