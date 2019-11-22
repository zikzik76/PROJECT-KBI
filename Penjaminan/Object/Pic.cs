using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Object
{
    public class Pic
    {
        public int id { get; set; }
       
        public int fk_mitra { get; set; }
        [Required]
        public string name { get; set; }

        public string jabatan { get; set; }

        public string noTelepon { get; set; }

        [Required]
        public string email { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }
}
