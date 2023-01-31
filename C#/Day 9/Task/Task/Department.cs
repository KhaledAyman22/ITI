namespace Task
{
    //Department
    // Employee should be removed from Department Staff List in both
    //Cases
    // If Employee Vacation Stock< 0
    // If Employee Age > 60
    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        List<Employee> Staff;

        public Department()
        {
            Staff = new List<Employee>();
        }

        public void AddStaff(Employee E)
        {
            if (E != null)
            {
                Staff.Add(E);

                E.EmployeeLayOff += RemoveStaff;
            }
        }

        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if(sender is Employee emp)
                Console.WriteLine($"Employee {emp.EmployeeID} is removed from department staff for {e.Cause}");
        }
    }

}