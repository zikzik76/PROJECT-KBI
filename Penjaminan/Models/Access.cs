using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class Access
    {
        public static PenjaminanViewDataset.AccessRow selectAccessByID(int id)
        {
            PenjaminanViewDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanViewDatasetTableAdapters.AccessTableAdapter();
            PenjaminanViewDataset.AccessDataTable dt = new PenjaminanViewDataset.AccessDataTable();
            PenjaminanViewDataset.AccessRow dr = null;

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
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }

        public static PenjaminanViewDataset.AccessRow selectAccess()
        {
            PenjaminanViewDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanViewDatasetTableAdapters.AccessTableAdapter();
            PenjaminanViewDataset.AccessDataTable dt = new PenjaminanViewDataset.AccessDataTable();
            PenjaminanViewDataset.AccessRow dr = null;

            try
            {
                ta.Fill(dt);

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

        public static void UpdateData(int id,int fk_role, int fk_page)
        {
            PenjaminanDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanDatasetTableAdapters.AccessTableAdapter();
            PenjaminanDataset.AccessDataTable dt = ta.GetDataByID(id);

            try
            {
                if (dt != null)
                {

                    dt[0].fk_page = fk_page;
                    dt[0].fk_role = fk_role;
                    dt[0].updateby = "1";
                    dt[0].updatedate = DateTime.Now;
                    

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static void UpdateDeleted(int id)
        {
            PenjaminanDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanDatasetTableAdapters.AccessTableAdapter();
            PenjaminanDataset.AccessDataTable dt = ta.GetDataRestore(id);

            try
            {
                if (dt != null)
                {

                    dt[0].deleted = "0";                   

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static int validasi(int fk_role, int fk_page)
        {
            PenjaminanDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanDatasetTableAdapters.AccessTableAdapter();
            PenjaminanDataset.AccessDataTable dt = ta.GetDataforVal(fk_role,fk_page);
            int value = 0;
            try
            {
                if (dt.Count != 0)
                {

                    value = 1;
                }
                else
                {
                    PenjaminanDataset.AccessDataTable dtx = new PenjaminanDataset.AccessDataTable();
                    PenjaminanDataset.AccessRow dr = null;
                    try
                    {
                        ta.Fillval2(dtx, fk_role, fk_page);
                        if(dtx.Count > 0)
                        {
                            dr = dtx[0];
                            UpdateDeleted(dr.id);

                            value = 2;
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message, ex);
                    }
                }
                return value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static void InsertData(int fk_role, int fk_page)
        {
            PenjaminanDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanDatasetTableAdapters.AccessTableAdapter();

            try
            {
                ta.Insert(fk_role, fk_page,"1",DateTime.Now,null,null,"0");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.AccessTableAdapter ta = new PenjaminanDatasetTableAdapters.AccessTableAdapter();
            PenjaminanDataset.AccessDataTable dt = ta.GetDataByID(id);

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