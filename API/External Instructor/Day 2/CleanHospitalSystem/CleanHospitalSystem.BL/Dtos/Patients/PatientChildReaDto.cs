namespace CleanHospitalSystem.BL;

public record PatientChildReaDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int IssuesCount { get; init; }
}
