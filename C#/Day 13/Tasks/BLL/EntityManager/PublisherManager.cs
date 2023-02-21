using BLL.Entity;
using BLL.EntityList;
using DAL;
using System.Data;
using System.Diagnostics;

namespace BLL.EntityManager
{
    public class PublisherManager
    {
        static DBManager manager = new();

        public static DataTable GetPublisherNamesWithIDs()
        {
            try
            {
                return manager.ExecuteDataTable("GetPublisherNamesWithIDs", new());

            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return new();
            }
        }

        #region Mapping

        internal static PublisherList DataTableToPublisherList(DataTable Dt)
        {
            PublisherList PrdLst = new();
            try
            {
                foreach (DataRow row in Dt.Rows)
                    PrdLst.Add(DataRowToPublisher(row));
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return PrdLst;
        }

        internal static Publisher DataRowToPublisher(DataRow Dr)
        {
            Publisher publisher = new();
            try
            {
                publisher.PublisherID = Dr["pub_id"]?.ToString() ?? "NA";
                publisher.PublisherName = Dr["pub_name"]?.ToString() ?? "NA";
                publisher.City = Dr["city"]?.ToString() ?? "NA";
                publisher.PublisherState = Dr["state"]?.ToString() ?? "NA";
                publisher.Country = Dr["country"]?.ToString() ?? "NA";

                publisher.State = EntityState.UnChanged;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return publisher;
        }

        #endregion

    }
}