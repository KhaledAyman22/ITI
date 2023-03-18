using FinalTask.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Contracts
{
    public interface ITrackRepo
    {
        public bool Create(Track obj);
        public bool Update(int id, Track obj);
        public bool Delete(Track obj);
        public Track? Read(int id);
        public ICollection<Track>? ReadAll();
        public DbSet<Track>? ReadAllQueryable();
    }
}
