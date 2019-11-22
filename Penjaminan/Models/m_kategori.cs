using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_kategori
    {
        public static PenjaminanDataset.m_kategoriRow selectKategoriByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();
            PenjaminanDataset.m_kategoriDataTable dt = new PenjaminanDataset.m_kategoriDataTable();
            PenjaminanDataset.m_kategoriRow dr = null;

            try
            {
                ta.FillKategoriByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load kategori data : " + ex.Message);
            }
        }
        public static PenjaminanDataset.m_kategoriRow SelectDataByName(string Nama)
        {
            PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();
            PenjaminanDataset.m_kategoriDataTable dt = new PenjaminanDataset.m_kategoriDataTable();
            PenjaminanDataset.m_kategoriRow dr = null;

            try
            {
                ta.FillByName(dt, Nama);

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
        public static void UpdateData(int Id, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();
            PenjaminanDataset.m_kategoriDataTable dt = ta.GetDataKategoriByID(Id);

            try
            {
                if (dt != null)
                {
                    dt[0].name = Name;
                    dt[0].description = Description;
                    dt[0].lastupdatedby = 1;
                    dt[0].lastupdateddate = DateTime.Now;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void InsertData(string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();

            try
            {
                ta.Insert(Name, Description, 1, DateTime.Now, 1, DateTime.Now, 0);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();
            PenjaminanDataset.m_kategoriDataTable dt = ta.GetDataKategoriByID(id);

            try
            {
                if (dt != null)
                {
                    dt[0].deleted = 1;

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