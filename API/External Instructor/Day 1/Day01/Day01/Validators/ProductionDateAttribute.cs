using System.ComponentModel.DataAnnotations;

namespace Day01.Validators
{
    public class ProductionDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value) =>
        value is DateTime date && date < DateTime.Now;

    }
}
