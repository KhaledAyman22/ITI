namespace CleanHospitalSystem.DAL;

public interface IPatientsRepo
{
    IEnumerable<Patient> GetByPatientsIds(int[] ids);
}
