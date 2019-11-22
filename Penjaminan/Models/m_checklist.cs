using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_checklist
    {
        public static void insertData(List<Object.Checklist> b, int idMitra, byte[] dataType)
        {
            PenjaminanDatasetTableAdapters.m_checklistTableAdapter ta = new PenjaminanDatasetTableAdapters.m_checklistTableAdapter();
            List<Models.m_checklist> tbuList = new List<Models.m_checklist>();


            
            foreach (var data in b)
            {
                try
                {

                    ta.InsertQuery(idMitra, data.id, data.FileName, "File Apa NIH", 1, DateTime.Now, 1, DateTime.Now, "0",10, dataType);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }
        }
        public static void Delete(int fkMitra)
        {
            PenjaminanDatasetTableAdapters.m_checklistTableAdapter taX = new PenjaminanDatasetTableAdapters.m_checklistTableAdapter();
            PenjaminanDataset.m_checklistDataTable dt = taX.GetDataBy2(Convert.ToDecimal(fkMitra));
            try
            {
                taX.softDelete("1",fkMitra);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

    }
}