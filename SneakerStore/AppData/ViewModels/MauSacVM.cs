using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class MauSacVM
    {
        public Guid Id { get; set; }
        [StringLength(25, ErrorMessage = "Màu sắc tối đa 25 ký tự")]
        public string TenMauSac { get; set; }
        public int TrangThai { get; set; }
    }
}
