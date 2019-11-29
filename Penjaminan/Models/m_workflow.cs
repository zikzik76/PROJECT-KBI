using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_workflow
    {
        public static PenjaminanDataset.m_workflowRow selectWorkflowByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_workflowTableAdapter ta = new PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
            PenjaminanDataset.m_workflowDataTable dt = new PenjaminanDataset.m_workflowDataTable();
            PenjaminanDataset.m_workflowRow dr = null;

            try
            {
                ta.FillWorkflowByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load workflow data : " + ex.Message);
            }
        }

        public static void UpdateData(int Id, int Sequence, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.m_workflowTableAdapter ta = new PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
            PenjaminanDataset.m_workflowDataTable dt = ta.GetDataWprkflowByID(Id);

            try
            {
                if (dt != null)
                {
                    dt[0].name = Name;
                    dt[0].sequence = Sequence;
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
            PenjaminanDatasetTableAdapters.m_workflowTableAdapter ta = new PenjaminanDatasetTableAdapters.m_workflowTableAdapter();

            try
            {
                ta.Insert(1,1,1, Name, Description, 1, DateTime.Now, 1, DateTime.Now, "0");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.m_workflowTableAdapter ta = new PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
            PenjaminanDataset.m_workflowDataTable dt = ta.GetDataWprkflowByID(id);

            try
            {
                if (dt != null)
                {
                    dt[0].deleted = "1";

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