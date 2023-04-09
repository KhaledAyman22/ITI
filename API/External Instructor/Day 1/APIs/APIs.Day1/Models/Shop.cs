using APIs.Day1.Validators;
using System.ComponentModel.DataAnnotations;

namespace APIs.Day1.Models;

public class Shop
{
    public int Id { get; set; }

    [StringLength(20, MinimumLength = 5, ErrorMessage = "The name should be between {2} and {1}")]
    public string Name { get; set; } = string.Empty;

    [DateInPast]
    public DateTime OpenDate { get; set; }

    //[RegularExpression("^(EG|USA|UAE)$")]
    public string Location { get; set; } = string.Empty; //EG,USA,UAE
}
