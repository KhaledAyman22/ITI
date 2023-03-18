using FinalTask.Contracts;
using FinalTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalTask.Repositories
{
    public class TraineeRepo : ITraineeRepo
    {
        private readonly TraineesDbContext _context;

        public TraineeRepo(TraineesDbContext context)
        {
            _context = context;
        }

        public bool Create(Trainee obj)
        {
            try
            {
                _context.Trainees.Add(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            _context.SaveChanges();
            return true;
        }

        public Trainee? Read(int id)
        {
            try
            {
                return _context.Trainees.Find(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        public bool Update(int id, Trainee obj)
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

        public bool Delete(Trainee obj)
        {
            try
            {
                _context.Trainees.Remove(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            _context.SaveChanges();
            return true;
        }

        

        public ICollection<Trainee>? ReadAll(bool includeTarck, bool includeCourse)
        {
            try
            {                
                
                if (includeCourse && includeTarck)
                    return _context.Trainees.Include(t => t.Course).Include(t => t.Track).ToList();
                
                if(includeTarck)
                    return _context.Trainees.Include(t => t.Track).ToList();
                
                if (includeCourse)
                    return _context.Trainees.Include(t => t.Course).ToList();
                
                return _context.Trainees.ToList();

            }
            catch (Exception ex) { 
                Debug.WriteLine(ex.Message);
            }

            return new List<Trainee>();
        }

        
    }
}
