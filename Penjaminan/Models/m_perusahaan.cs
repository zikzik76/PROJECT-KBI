using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_perusahaan
    {
        public static PenjaminanDataset.m_perusahaanRow selectPerusahaanByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter();
            PenjaminanDataset.m_perusahaanDataTable dt = new PenjaminanDataset.m_perusahaanDataTable();
            PenjaminanDataset.m_perusahaanRow dr = null;

            try
            {
                ta.FillPerusahaanByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load perusahaan data : " + ex.Message);
            }
        }

        public static void UpdateData(int Id, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter();
            PenjaminanDataset.m_perusahaanDataTable dt = ta.GetDataPerusahaanByID(Id);

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
            PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter();

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
            PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter();
            PenjaminanDataset.m_perusahaanDataTable dt = ta.GetDataPerusahaanByID(id);

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