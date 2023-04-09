using CleanHospitalSystem.BL.Dtos;
using CleanHospitalSystem.DAL;

namespace CleanHospitalSystem.BL;

public class DoctorsManager : IDoctorsManager
{
    private readonly IDoctorsRepo _doctorsRepo;
    private readonly IPatientsRepo _patientsRepo;

    public DoctorsManager(IDoctorsRepo doctorsRepo,
        IPatientsRepo patientsRepo)
    {
        _doctorsRepo = doctorsRepo;
        _patientsRepo = patientsRepo;
    }

    public IEnumerable<DoctorReadDto> GetAll()
    {
        var doctorsFromDb = _doctorsRepo.GetAll();

        return doctorsFromDb.Select(d => new DoctorReadDto(Id: d.Id,
                Name: d.Name,
                Specialization: d.Specialization,
                PerformanceRate: d.PerformanceRate));
    }

    public DoctorDetailsReadDto? GetDetailsById(int id)
    {
        //I need a method to retunr the database model for doctor by Id
        //Including his patients, Including PatientIssues
        Doctor? doctorFromDb = _doctorsRepo.GetWithPatientsWithIssuesById(id);

        if (doctorFromDb is null)
        {
            return null;
        }

        return new DoctorDetailsReadDto
        {
            Id = doctorFromDb.Id,
            Name = doctorFromDb.Name,
            Patints = doctorFromDb.Patinets
                .Select(p => new PatientChildReaDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    IssuesCount = p.Issues.Count
                })
        };
    }

    public void AssignPatientsToDoctor(AssignPatientsToDoctorDto assignPatientsDto)
    {
        //Get Doctor from Repo 
        Doctor? doctor = _doctorsRepo.GetWithPatientsById(assignPatientsDto.DoctorId);
        if (doctor is null)
        {
            return;
        }
        //Clear Doctor Patients
        doctor.Patinets.Clear();
        //Get New patients From Db
        ICollection<Patient> newPatients = _patientsRepo
            .GetByPatientsIds(assignPatientsDto.PatientsIds)
            .ToList();
        //Assign New patients to Doctor
        doctor.Patinets = newPatients;
        //SaveChanges
        _doctorsRepo.SaveChanges();
    }
}
