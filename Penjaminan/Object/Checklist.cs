using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Object
{
    public class Checklist
    {
        public int id { get; set; }
        public int fk_kategori { get; set; }
        public int fk_mitra { get; set; }
        public string name { get; set; }
        public string FileName { get; set; }
        public string fileType { get; set; }
        public string fileSize { get; set; }
        public string description { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
        public string kategoriname { get; set; }
    }
}
