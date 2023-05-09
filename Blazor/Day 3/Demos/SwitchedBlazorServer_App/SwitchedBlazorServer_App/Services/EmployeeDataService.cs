using SharedLibrary;
using System.Net.Http.Json;

namespace BlazorWebAssembly_43.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public HttpClient HttpClient { get; }
        public EmployeeDataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Employee>>("/api/Employee");
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return await HttpClient.GetFromJsonAsync<Employee>("/api/Employee/"+employeeId);
        }

        public  async Task UpdateEmployee(Employee employee)
        {
            await HttpClient.PutAsJsonAsync("/api/Employee/"+employee.EmployeeId, employee);
        }

        public async Task AddEmployee(Employee employee)
        {
            await HttpClient.PostAsJsonAsync<Employee>("/api/Employee/", employee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await HttpClient.DeleteAsync("/api/Employee/"+employeeId);
        }

    }
}
