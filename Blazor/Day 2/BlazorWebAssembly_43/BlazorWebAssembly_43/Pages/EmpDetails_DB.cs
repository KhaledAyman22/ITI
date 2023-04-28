using BlazorWebAssembly_43.Services;
using Microsoft.AspNetCore.Components;
using SharedLibrary;

namespace BlazorWebAssembly_43.Pages
{
    public partial class EmpDetails_DB
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee CurEmp { get; set; }

        [Inject]
        public IEmployeeDataService empDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurEmp = await empDataService.GetEmployeeDetails(EmployeeId);
        }
    }
}
