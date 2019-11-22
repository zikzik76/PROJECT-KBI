using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Models
{
    class ApplicationLog
    {
        public static void insertLog(string module, string action, string id, string description, int userid)
        {
            PenjaminanDatasetTableAdapters.ApplicationLogTableAdapter ta = new PenjaminanDatasetTableAdapters.ApplicationLogTableAdapter();
            ta.Insert(module, action, id, description, userid, DateTime.Now);
        }
    }
}
