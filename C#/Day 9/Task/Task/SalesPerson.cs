namespace Task
{
    //Sales Employee & Board Member
    // Sales Employee Doesn’t have Vacation Stock 
    // Sales Employee Will not be Fired if his/her Vacation Stock<0
    // Sales Employee have a target to Achieve 
    // Sales Employee will be Fired if Failed to Achieve Sales Target
    
    class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        
        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget >= Quota) return true;

            OnEmployeeLayOff(new(){ Cause = LayOffCause.BelowTarget });
            return false;
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if(e.Cause == LayOffCause.BelowTarget || e.Cause == LayOffCause.Age)
                base.OnEmployeeLayOff(e);
        }
    }
}