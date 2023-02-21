using BLL.Entity;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class TitleManager
    {
        static DBManager manager = new();

        public static bool UpdateTitle(Title title)
        {
            try
            {
                Dictionary<string, object> ParamDic = new()
                {
                    ["@title_id"] = title.TitleID,
                    ["@title"] = title.TitleName,
                    ["@type"] = title.Type,
                    ["@pub_id"] = title?.PublisherID??"0736",
                    ["@price"] = title?.Price??0,
                    ["@advance"] = title?.Advance??0,
                    ["@royalty"] = title?.Royalty??0,
                    ["@ytd_sales"] = title?.YTDSales??0,
                    ["@notes"] = title?.Notes??"",
                    ["@pubdate"] = title?.PublishDate??new(1999,1,1),
                };

                if (manager.ExecuteNonQuery("UpdateTitle", ParamDic) > 0)
                {
                    title.State = EntityState.UnChanged;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return false;
        }

        public static bool InsertTitle(Title title)
        {
            try
            {
                Dictionary<string, object> ParamDic = new()
                {
                    ["@title_id"] = title.TitleID,
                    ["@title"] = title.TitleName,
                    ["@type"] = title.Type,
                    ["@pub_id"] = title.PublisherID,
                    ["@price"] = title.Price,
                    ["@advance"] = title.Advance,
                    ["@royalty"] = title.Royalty,
                    ["@ytd_sales"] = title.YTDSales,
                    ["@notes"] = title.Notes,
                    ["@pubdate"] = title.PublishDate,
                };


                if (manager.ExecuteNonQuery("InsertTitle", ParamDic) > 0)
                {
                    title.State = EntityState.UnChanged;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return false;
        }

        public static bool DeleteTitle(Title title)
        {
            try
            {
                Dictionary<string, object> ParamDic = new()
                {
                    ["@title_id"] = title.TitleID,
                };

                return manager.ExecuteNonQuery("DeleteTitle", ParamDic) > 0;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return false;
        }

        public static TitleList SelectAllTitles()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("SelectAllTitles"));
            }
            catch
            {
                return new TitleList();
            }
        }

        public static bool Save(List<Title> list)
        {
            try
            {
                foreach (var item in list)
                {
                    switch (item.State)
                    {
                        case EntityState.Changed: UpdateTitle(item); break;
                        case EntityState.Added: InsertTitle(item); break;
                        case EntityState.Deleted: DeleteTitle(item); break;
                        case EntityState.UnChanged:
                        default: break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;   
            }
        }


        #region Mapping

        internal static TitleList DataTableToTitleList(DataTable Dt)
        {
            TitleList PrdLst = new();
            try
            {
                foreach (DataRow row in Dt.Rows)
                    PrdLst.Add(DataRowToProduct(row));
            }
            catch
            {

            }
            return PrdLst;
        }

        internal static Title DataRowToProduct(DataRow Dr)
        {
            Title title = new();
            try
            {
                title.TitleID = Dr["title_id"]?.ToString() ?? "NA";
                title.TitleName = Dr["title"]?.ToString() ?? "";
                title.Type = Dr["type"]?.ToString() ?? "";
                title.PublisherID = Dr["pub_id"]?.ToString() ?? "";
                title.Notes = Dr["notes"]?.ToString() ?? "";


                if (decimal.TryParse(Dr["price"]?.ToString() ?? "-1", out decimal TempDecimal))
                    title.Price = TempDecimal;


                if (decimal.TryParse(Dr["advance"]?.ToString() ?? "-1", out TempDecimal))
                    title.Advance = TempDecimal;


                if (int.TryParse(Dr["royalty"]?.ToString() ?? "-1", out int TempInt))
                    title.Royalty = TempInt;


                if (int.TryParse(Dr["ytd_sales"]?.ToString() ?? "-1", out TempInt))
                    title.YTDSales = TempInt;


                if (DateTime.TryParse(Dr["pubdate"]?.ToString() ?? "1-1-1999", out DateTime TempDateTime))
                    title.PublishDate = TempDateTime;


                title.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return title;
        }
        #endregion

    }
}
