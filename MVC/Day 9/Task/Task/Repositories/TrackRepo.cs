using System.Diagnostics;
using FinalTask.Contracts;
using FinalTask.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Repositories
{
    public class TrackRepo : ITrackRepo
    {
        private readonly TraineesDbContext _context;
        
        public TrackRepo(TraineesDbContext context)
        {
            _context = context;
        }
        
        public bool Create(Track obj)
        {
            try
            {
                _context.Tracks.Add(obj);
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            _context.SaveChanges();
            return true;
        }

        public Track? Read(int id)
        {
            try
            {
                return _context.Tracks.Find(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            return null;
        }
        
        public bool Update(int id, Track obj)
        {
            try
            {
                _context.Update(obj);
                //_context.Tracks.Remove(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            _context.SaveChanges();
            return true;
        }
        
        public bool Delete(Track obj)
        {
            try
            {
                _context.Tracks.Remove(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            _context.SaveChanges();
            return true;
        }
        
        public ICollection<Track>? ReadAll()
        {
            try
            {
                return _context.Tracks.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Track>();
        }

        public DbSet<Track>? ReadAllQueryable()
        {
            try
            {
                _context.Tracks.Load();
                return _context.Tracks;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
