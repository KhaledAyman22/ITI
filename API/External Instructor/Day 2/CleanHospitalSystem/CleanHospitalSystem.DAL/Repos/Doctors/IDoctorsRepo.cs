namespace CleanHospitalSystem.DAL;

public interface IDoctorsRepo
{
    IEnumerable<Doctor> GetAll();
    Doctor? GetWithPatientsWithIssuesById(int id);
    Doctor? GetWithPatientsById(int id);
    int SaveChanges();
}
