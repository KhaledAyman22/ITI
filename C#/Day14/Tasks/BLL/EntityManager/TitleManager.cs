using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;

namespace BLL.EntityManager
{
    public class TitleManager
    {
        static PubsContext context = new();

        public static BindingList<Title> SelectAllTitlesWithBinding()
        {
            try
            {
                context.Titles.Load();
                return context.Titles.Local.ToBindingList();
            }
            catch
            {
                return new();
            }
        }

        public static bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                context = new();
                Trace.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
