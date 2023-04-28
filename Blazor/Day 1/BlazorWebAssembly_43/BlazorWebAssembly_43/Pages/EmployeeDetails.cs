using Microsoft.AspNetCore.Components;
using SharedLibrary;

namespace BlazorWebAssembly_43.Pages
{
    public partial class EmployeeDetails
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee CurEmp { get; set; }

        protected override Task OnInitializedAsync()
        {
            CurEmp = MockContext.Employees.FirstOrDefault(em => em.EmployeeId == EmployeeId);

            return base.OnInitializedAsync();
        }
    }
}
