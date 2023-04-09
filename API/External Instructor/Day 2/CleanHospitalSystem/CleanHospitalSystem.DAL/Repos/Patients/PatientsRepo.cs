namespace CleanHospitalSystem.DAL;

public class PatientsRepo : IPatientsRepo
{
    private readonly HospitalContext _context;

    public PatientsRepo(HospitalContext context)
    {
        _context = context;
    }

    public IEnumerable<Patient> GetByPatientsIds(int[] ids)
    {
        /*
         * select * from Patients
         * where Id in (select id from ids)
         */
        return _context.Set<Patient>()
            .Where(p => ids.Contains(p.Id));
    }
}
