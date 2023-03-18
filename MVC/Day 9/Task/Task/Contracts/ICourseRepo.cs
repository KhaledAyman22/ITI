using FinalTask.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Contracts
{
    public interface ICourseRepo
    {
        public bool Create(Course obj);
        public bool Update(int id, Course obj);
        public bool Delete(Course obj);
        public Course? Read(int id);
        public ICollection<Course>? ReadAll();
        public DbSet<Course>? ReadAllQueryable();
    }
}
