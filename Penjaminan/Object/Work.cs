using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Penjaminan.Object
{
    public class WorkDone
    {
        public int id { get; set; }
        public int fk_mitra { get; set; }
        public string tipe { get; set; }
        public string namapaket { get; set; }
        public string lokasi { get; set; }
        [Required]
        public DateTime tanggalpelaksanaan { get; set; }
        [Required]
        public decimal nilai { get; set; }
        [Required]
        public DateTime tanggalserah { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }
    public class WorkDone2
    {
        public int id { get; set; }
        public int fk_mitra { get; set; }
        public int fk_workdown { get; set; }
        public string tipe { get; set; }
        public string namapaket { get; set; }
        public string lokasi { get; set; }

        [Required]
        public DateTime tanggalpelaksanaan { get; set; }

        [Required]
        public decimal nilai { get; set; }

        [Required]
        public DateTime tanggalserah { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }

    public class WorkProgress
    {
        public int id { get; set; }
        public int fk_mitra { get; set; }
        public int fk_wpID { get; set; }
        public string tipe { get; set; }
        public string namapaket { get; set; }
        public string lokasi { get; set; }

        [Required]
        public DateTime tanggalpelaksanaan { get; set; }

        [Required]
        public decimal nilai { get; set; }

        [Required]
        public DateTime tanggalserah { get; set; }
        public int createdby { get; set; }
        public DateTime createddate { get; set; }
        public int lastupdatedby { get; set; }
        public DateTime lastupdateddate { get; set; }
        public int deleted { get; set; }
    }
}