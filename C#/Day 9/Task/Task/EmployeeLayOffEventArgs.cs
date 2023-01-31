namespace Task
{
    public enum LayOffCause
    {
        ExcessVacation = 0, Age = 1, BelowTarget = 2, Resign = 3
    }

    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }

}