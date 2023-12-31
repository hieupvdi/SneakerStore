﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string UrlAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }


        public virtual User? User { get; set; }
    }
}
