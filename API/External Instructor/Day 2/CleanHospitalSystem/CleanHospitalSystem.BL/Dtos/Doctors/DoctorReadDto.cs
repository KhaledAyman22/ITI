namespace CleanHospitalSystem.BL.Dtos;

public record DoctorReadDto(int Id,
    string Name,
    string Specialization,
    int PerformanceRate);