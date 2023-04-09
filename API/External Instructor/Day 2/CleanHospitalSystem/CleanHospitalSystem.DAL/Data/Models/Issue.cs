namespace CleanHospitalSystem.DAL;

public class Issue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();

}
