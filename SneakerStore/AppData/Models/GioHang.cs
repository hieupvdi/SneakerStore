﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHang
    {
        public Guid IdUser { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<GioHangCT> GioHangCTs { get; set; }
      
    }
}
