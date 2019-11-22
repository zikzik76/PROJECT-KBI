using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_document
    {
        public static PenjaminanDataset.m_documentRow selectDocumentByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_documentTableAdapter ta = new PenjaminanDatasetTableAdapters.m_documentTableAdapter();
            PenjaminanDataset.m_documentDataTable dt = new PenjaminanDataset.m_documentDataTable();
            PenjaminanDataset.m_documentRow dr = null;

            try
            {
                ta.FillDocumentByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load document data : " + ex.Message);
            }
        }

        public static void UpdateData(int Id,int kategoryID, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_documentTableAdapter ta = new PenjaminanDatasetTableAdapters.m_documentTableAdapter();
            PenjaminanDataset.m_documentDataTable dt = ta.GetDataDocumentByID(Id);

            try
            {
                if (dt != null)
                {
                    dt[0].fk_kategori = kategoryID;
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

        public static void InsertData(int KategoriID,string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_documentTableAdapter ta = new PenjaminanDatasetTableAdapters.m_documentTableAdapter();

            try
            {
                ta.Insert(KategoriID, Name, Description, 1, DateTime.Now, 1, DateTime.Now, 0);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.m_documentTableAdapter ta = new PenjaminanDatasetTableAdapters.m_documentTableAdapter();
            PenjaminanDataset.m_documentDataTable dt = ta.GetDataDocumentByID(id);

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