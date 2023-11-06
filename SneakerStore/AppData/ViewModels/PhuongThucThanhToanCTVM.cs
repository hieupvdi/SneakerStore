using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class PhuongThucThanhToanCTVM
    {
        public Guid Id { get; set; }
        public decimal SoTien { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdPTTT { get; set; }
        public int TrangThai { get; set; }
        //join
        public string ?MaHD { get; set; }
        public string ?TenPT { get; set;}

    }
}
