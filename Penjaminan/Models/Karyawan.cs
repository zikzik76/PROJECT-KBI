using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class Karyawan
    {
        public static PenjaminanDataset.KaryawanRow selectKaryawanByID(int id)
        {
            PenjaminanDatasetTableAdapters.KaryawanTableAdapter ta = new PenjaminanDatasetTableAdapters.KaryawanTableAdapter();
            PenjaminanDataset.KaryawanDataTable dt = new PenjaminanDataset.KaryawanDataTable();
            PenjaminanDataset.KaryawanRow dr = null;

            try
            {
                ta.FillByjoin(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }

       
        public static void UpdateData(int id ,string Name, int divisiID, string alamat)
        {
            PenjaminanDatasetTableAdapters.KaryawanTableAdapter ta = new PenjaminanDatasetTableAdapters.KaryawanTableAdapter();
            PenjaminanDataset.KaryawanDataTable dt = ta.GetDataByID(id);

            try
            {
                if (dt != null)
                {
                   
                    dt[0].Nama = Name;
                    dt[0].DivisiID = divisiID;
                    dt[0].Alamat = alamat;
                    //dt[0].NamaDivisi = NamaDivisi;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void InsertData(string Nama, int DivisiID, string Alamat)
        {
            PenjaminanDatasetTableAdapters.KaryawanTableAdapter ta = new PenjaminanDatasetTableAdapters.KaryawanTableAdapter();

            try
            {
                ta.Insert( Nama, DivisiID, Alamat, false,"Sangsi");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.KaryawanTableAdapter ta = new PenjaminanDatasetTableAdapters.KaryawanTableAdapter();
            PenjaminanDataset.KaryawanDataTable dt = ta.GetDataByID(id);

            try
            {
                if (dt != null)
                {
                    dt[0].isDelete = true;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}