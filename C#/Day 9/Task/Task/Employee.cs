namespace Task
{

    //  Company will Lay off All Type of Employees in Two Cases 
    // If Employee Vacation Stock< 0
    // If Employee Age > 60

    class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        
        protected virtual void OnEmployeeLayOff (EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }
        
        public DateTime BirthDate { get; init; }

        private int _vacationStock;
        
        public int VacationStock{ get { return _vacationStock; } init { _vacationStock = value; } }

        public bool RequestVacation(DateTime From, DateTime To)
        {
            int days = (int)(To - From).TotalDays;
            _vacationStock -= days;

            if(_vacationStock < 0)
            {
                OnEmployeeLayOff(new() { Cause = LayOffCause.ExcessVacation });
                return false;
            }

            return true;
        }
        
        public void EndOfYearOperation()
        {
            double age = (DateTime.Now - BirthDate).TotalDays / 356;

            if(age > 60)
                OnEmployeeLayOff(new() { Cause = LayOffCause.Age });
        }
    }

}