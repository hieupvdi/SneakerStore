using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHang
    {
        public Guid IDUser { get; set; }
        public virtual ApplicationUser User { get; set; }       
    }
}
