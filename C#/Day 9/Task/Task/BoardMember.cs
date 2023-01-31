namespace Task
{
    class BoardMember : Employee
    {
        // Board Member has no retiring Age (will not be Fired if AGE > 60)
        // Board Member is not a Full time Employee(Has no vacation Stock)
        // Board Member will be layoff from the Company in case He/She Resigned.
        // Board Member will forever be a Member of Company Clubs

        public void Resign()
        {
            OnEmployeeLayOff(new() { Cause = LayOffCause.Resign });
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if(e.Cause == LayOffCause.Resign)
                base.OnEmployeeLayOff(e);
        }
    }

}