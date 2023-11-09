using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class AnhSanPhamVM
    {
        public Guid Id { get; set; }
        public Guid IdCTSP { get; set; }
        public string URlAnh { get; set; }
        public string? Tensp { get; set; }
		public int AnhSo { get; set; }
		public int TrangThai { get; set; }
    }
}
