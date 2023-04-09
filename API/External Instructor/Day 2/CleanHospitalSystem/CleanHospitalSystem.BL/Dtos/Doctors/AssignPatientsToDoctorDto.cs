namespace CleanHospitalSystem.BL.Dtos;

public record AssignPatientsToDoctorDto(int DoctorId, int[] PatientsIds);
