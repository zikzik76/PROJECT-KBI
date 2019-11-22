using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_divisi
    {
        public static PenjaminanDataset.DivisiRow selectDivisiByID(int id)
        {
            PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new PenjaminanDatasetTableAdapters.DivisiTableAdapter();
            PenjaminanDataset.DivisiDataTable dt = new PenjaminanDataset.DivisiDataTable();
            PenjaminanDataset.DivisiRow dr = null;

            try
            {
                ta.FillByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Divisi data : " + ex.Message);
            }
        }
        public static PenjaminanDataset.DivisiRow selectIDByNamaDivisi(string Nama)
        {
            PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new PenjaminanDatasetTableAdapters.DivisiTableAdapter();
            PenjaminanDataset.DivisiDataTable dt = new PenjaminanDataset.DivisiDataTable();
            PenjaminanDataset.DivisiRow dr = null;

            try
            {
                ta.FillByNamaDivisi(dt, Nama);

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
        public static void UpdateData(int Id, string NamaDivisi)
        {
            PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new PenjaminanDatasetTableAdapters.DivisiTableAdapter();
            PenjaminanDataset.DivisiDataTable dt = ta.GetDataByID(Id);

            try
            {
                if (dt != null)
                {
                    //dt[0].ID = Id;
                    dt[0].NamaDivisi = NamaDivisi;
                    

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void InsertData(string Name)
        {
            PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new PenjaminanDatasetTableAdapters.DivisiTableAdapter();

            try
            {
                ta.Insert(Name);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void Delete(int id)
        {
            PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new PenjaminanDatasetTableAdapters.DivisiTableAdapter();
            PenjaminanDataset.DivisiDataTable dt = ta.GetDataByID(id);

            try
            {
                if (dt != null)
                {
                    dt[0].Delete();

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