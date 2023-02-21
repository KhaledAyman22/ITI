using BLL.HelperEntity;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace BLL.EntityManager
{
    public class PublisherManager
    {
        static PubsContext context = new();

        public static List<PublisherWithID> GetPublisherNamesWithIDs()
        {
            try
            {
                //context.Publishers.Load();
                return context.Publishers.Select(i=> new PublisherWithID{ PubId = i.PubId, PubName = i.PubName }).ToList();

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return new();
            }
        }
    }
}