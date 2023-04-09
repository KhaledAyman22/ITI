using System.ComponentModel.DataAnnotations;

namespace APIs.Day1.Validators;

public class DateInPastAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        value is DateTime date && date < DateTime.Now;

    //public override bool IsValid(object? value)
    //{
    //    DateTime? date = value as DateTime?; 
    //    if (date is null)
    //    {
    //        return false;
    //    }

    //    if (date < DateTime.Now)
    //        return true;
    //    else return false;
    //}
}
