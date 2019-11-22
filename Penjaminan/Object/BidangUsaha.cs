using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Object
{
    public class m_bidangusaha
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }

    public class t_bidangusaha
    {
        public int id { get; set; }
        public decimal fk_bidangusaha { get; set; }       
        public decimal fk_mitra { get; set; }
        public decimal createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
        public string name_bidangusaha { get; set; }
    }
}
