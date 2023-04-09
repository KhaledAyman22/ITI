namespace CleanHospitalSystem.DAL;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PerformanceRate { get; set; }
    public decimal Salary { get; set; }
    public string Specialization { get; set; }= string.Empty;

    public ICollection<Patient> Patinets { get; set; } = new HashSet<Patient>();
}
