using Microsoft.EntityFrameworkCore;

namespace CleanHospitalSystem.DAL;

public class DoctorsRepo : IDoctorsRepo
{
    private readonly HospitalContext _context;

    public DoctorsRepo(HospitalContext context)
    {
        _context = context;
    }
    public IEnumerable<Doctor> GetAll()
    {
        return _context.Set<Doctor>();
    }

    public Doctor? GetWithPatientsById(int id)
    {
        return _context.Set<Doctor>()
                .Include(d => d.Patinets)
                .FirstOrDefault(d => d.Id == id);
    }

    public Doctor? GetWithPatientsWithIssuesById(int id)
    {
        return _context.Set<Doctor>()
                .Include(d => d.Patinets)
                    .ThenInclude(p => p.Issues)
                .FirstOrDefault(d => d.Id == id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
