using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CleanHospitalSystem.DAL;

public class HospitalContext : DbContext
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Issue> Issues => Set<Issue>();


    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Seeding Docs
        var doctors = JsonSerializer.Deserialize<List<Doctor>>("""[{"Id":1,"Name":"Jessie","Specialization":"Hematology","Salary":27064,"PerformanceRate":65},{"Id":2,"Name":"Judy","Specialization":"Neurology","Salary":18711,"PerformanceRate":32},{"Id":3,"Name":"Naomi","Specialization":"Pediatrics","Salary":32145,"PerformanceRate":27},{"Id":4,"Name":"Joann","Specialization":"Hematology","Salary":9232,"PerformanceRate":72},{"Id":5,"Name":"Judy","Specialization":"Dermatology","Salary":48498,"PerformanceRate":19},{"Id":6,"Name":"Alyssa","Specialization":"Gastroenterology","Salary":16586,"PerformanceRate":79},{"Id":7,"Name":"Mable","Specialization":"Infectious Disease","Salary":33706,"PerformanceRate":5},{"Id":8,"Name":"Paula","Specialization":"Urology","Salary":19094,"PerformanceRate":0},{"Id":9,"Name":"Rafael","Specialization":"Pediatrics","Salary":12266,"PerformanceRate":97},{"Id":10,"Name":"Sara","Specialization":"Pediatrics","Salary":45041,"PerformanceRate":82}]""") ?? new();
        #endregion
        #region Patients
        var patients = JsonSerializer.Deserialize<List<Patient>>("""[{"Id":1,"Name":"Dana","DoctorId":5},{"Id":2,"Name":"Isaac","DoctorId":7},{"Id":3,"Name":"Damon","DoctorId":9},{"Id":4,"Name":"Miriam","DoctorId":8},{"Id":5,"Name":"Terence","DoctorId":7},{"Id":6,"Name":"Roosevelt","DoctorId":1},{"Id":7,"Name":"Eduardo","DoctorId":9},{"Id":8,"Name":"Wilbert","DoctorId":8},{"Id":9,"Name":"Tasha","DoctorId":5},{"Id":10,"Name":"Max","DoctorId":1},{"Id":11,"Name":"Bridget","DoctorId":2},{"Id":12,"Name":"Juan","DoctorId":8},{"Id":13,"Name":"Krystal","DoctorId":10},{"Id":14,"Name":"Erma","DoctorId":10},{"Id":15,"Name":"Orlando","DoctorId":6},{"Id":16,"Name":"Marvin","DoctorId":5},{"Id":17,"Name":"Lamar","DoctorId":4},{"Id":18,"Name":"Joe","DoctorId":7},{"Id":19,"Name":"Wendell","DoctorId":8},{"Id":20,"Name":"Sandra","DoctorId":4},{"Id":21,"Name":"Stephanie","DoctorId":6},{"Id":22,"Name":"Ervin","DoctorId":7},{"Id":23,"Name":"Beth","DoctorId":4},{"Id":24,"Name":"Gretchen","DoctorId":7},{"Id":25,"Name":"Gwendolyn","DoctorId":2},{"Id":26,"Name":"Jerry","DoctorId":7},{"Id":27,"Name":"Mitchell","DoctorId":6},{"Id":28,"Name":"Maggie","DoctorId":8},{"Id":29,"Name":"Sandy","DoctorId":3},{"Id":30,"Name":"Lloyd","DoctorId":2}]""") ?? new();
        #endregion
        #region Issues
        var issues = JsonSerializer.Deserialize<List<Issue>>("""[{"Id":1,"Name":"Diabetes"},{"Id":2,"Name":"Hypertension"},{"Id":3,"Name":"Asthma"},{"Id":4,"Name":"Depression"},{"Id":5,"Name":"Arthritis"},{"Id":6,"Name":"Allergy"},{"Id":7,"Name":"Flu"}]""") ?? new();
        #endregion

        modelBuilder.Entity<Doctor>().HasData(doctors);
        modelBuilder.Entity<Patient>().HasData(patients);
        modelBuilder.Entity<Issue>().HasData(issues);

    }
}
