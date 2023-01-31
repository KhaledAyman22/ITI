namespace Task
{
    //Club
    // Employee should be removed from Club Member List Only if Employee Vacation Stock< 0.
    // If Employee Age> 60 will still remain a Member of Company Club
    class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members;

        public Club()
        {
            Members = new List<Employee>();
        }

        public void AddMember(Employee E)
        {
            if (E != null)
            {
                Members.Add(E);
                
                if(E is not BoardMember)
                {
                    E.EmployeeLayOff += RemoveMember;
                }
            }
        }
        
        ///CallBackMethod
        public void RemoveMember (object sender, EmployeeLayOffEventArgs e)
        {
            ///Employee Will not be removed from the Club if Age > 60
            ///Employee will be removed from Club if Vacation Stock < 0

            if (sender is Employee emp && e.Cause != LayOffCause.Age)
                Console.WriteLine($"Employee {emp.EmployeeID} is removed from club members for {e.Cause}");
        }
    }
}