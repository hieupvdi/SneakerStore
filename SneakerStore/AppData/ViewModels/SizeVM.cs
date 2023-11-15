using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class SizeVM
    {
        public Guid Id { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Size phải là số")]
        public int SizeNumber { get; set; }
        public int TrangThai { get; set; }
    }
}
