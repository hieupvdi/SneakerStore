﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(1, 5, ErrorMessage = "Số ảnh tù 1 => 5")]
        public int AnhSo { get; set; }
		public int TrangThai { get; set; }
    }
}
