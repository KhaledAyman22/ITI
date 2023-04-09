namespace CleanHospitalSystem.BL;

public record DoctorDetailsReadDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public IEnumerable<PatientChildReaDto> Patints { get; init; }
        = new List<PatientChildReaDto>();
}