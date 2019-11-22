using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_pipeline
    {
        public static PenjaminanDataset.m_pipelineRow selectPipelineByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_pipelineTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pipelineTableAdapter();
            PenjaminanDataset.m_pipelineDataTable dt = new PenjaminanDataset.m_pipelineDataTable();
            PenjaminanDataset.m_pipelineRow dr = null;

            try
            {
                ta.FillPipelineByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load pipeline data : " + ex.Message);
            }
        }

        public static void UpdateData(int Id, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_pipelineTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pipelineTableAdapter();
            PenjaminanDataset.m_pipelineDataTable dt = ta.GetDataPipelineByID(Id);

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
            PenjaminanDatasetTableAdapters.m_pipelineTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pipelineTableAdapter();

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
            PenjaminanDatasetTableAdapters.m_pipelineTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pipelineTableAdapter();
            PenjaminanDataset.m_pipelineDataTable dt = ta.GetDataPipelineByID(id);

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