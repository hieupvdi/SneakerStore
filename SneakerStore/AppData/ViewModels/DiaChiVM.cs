using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class DiaChiVM
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        //[StringLength(150, MinimumLength = 5, ErrorMessage = "Địa chỉ tối đa 150 ký tự và tối thiểu 5 ký tự")]
        public string Ten { get; set; }
        public int TrangThai { get; set; }
    

    }
}
