using FinalTask.Models;

namespace FinalTask.Contracts
{
    public interface ITraineeRepo
    {
        public bool Create(Trainee obj);
        public bool Update(int id, Trainee obj);
        public bool Delete(Trainee obj);
        public Trainee? Read(int id);
        public ICollection<Trainee>? ReadAll(bool includeTarck, bool includeCourse);
    }
}
