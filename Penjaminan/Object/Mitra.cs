using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
namespace Penjaminan.Object
{
    public class m_mitra
    {
       
            public int id { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public string latarbelakang { get; set; }
            public int createdby { get; set; }
            public DateTime createddate { get; set; }
            public int lastupdatedby { get; set; }
            public DateTime lastupdateddate { get; set; }
            public int deleted { get; set; }
        }

   
}