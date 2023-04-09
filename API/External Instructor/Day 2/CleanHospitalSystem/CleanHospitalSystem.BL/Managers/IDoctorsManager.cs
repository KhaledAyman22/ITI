using CleanHospitalSystem.BL.Dtos;

namespace CleanHospitalSystem.BL;

public interface IDoctorsManager
{
    void AssignPatientsToDoctor(AssignPatientsToDoctorDto assignPatientsDto);
    IEnumerable<DoctorReadDto> GetAll();
    DoctorDetailsReadDto? GetDetailsById(int id);
}
