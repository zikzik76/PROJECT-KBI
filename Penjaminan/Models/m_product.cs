using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_product
    {
        public static PenjaminanDataset.m_productRow selectProductByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_productTableAdapter ta = new PenjaminanDatasetTableAdapters.m_productTableAdapter();
            PenjaminanDataset.m_productDataTable dt = new PenjaminanDataset.m_productDataTable();
            PenjaminanDataset.m_productRow dr = null;

            try
            {
                ta.FillProductByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load product data : " + ex.Message);
            }
        }

        public static void UpdateData(int Id, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_productTableAdapter ta = new PenjaminanDatasetTableAdapters.m_productTableAdapter();
            PenjaminanDataset.m_productDataTable dt = ta.GetDataProductByID(Id);

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
            PenjaminanDatasetTableAdapters.m_productTableAdapter ta = new PenjaminanDatasetTableAdapters.m_productTableAdapter();

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
            PenjaminanDatasetTableAdapters.m_productTableAdapter ta = new PenjaminanDatasetTableAdapters.m_productTableAdapter();
            PenjaminanDataset.m_productDataTable dt = ta.GetDataProductByID(id);

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