using FinalDemo_43.Models;
using System.Collections.Generic;

namespace FinalDemo_43.RepoServices
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Student GetDetails(int id);
        public void Insert(Student std);
        public void UpdateStd(int id, Student std);
        public void DeleteStd(int id);
    }
}
