using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Object
{
    public class BoardOfDirector
    {
        public int id { get; set; }
        public int fk_mitra { get; set; }
        public string name { get; set; }
        public string jabatan { get; set; }
        public DateTime tglLahir { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }
}
