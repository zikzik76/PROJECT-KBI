using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Object
{
    public class PemegangSaham
    {
        public int id { get; set; }
        public int fk_mitra { get; set; }
        public string name { get; set; }
        public decimal jumlah { get; set; }
        public decimal total { get; set; }
        public decimal persentase { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }
}
