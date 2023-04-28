using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Track
    {
        [Key]
        public int ID { get; set; }
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)?$", ErrorMessage = "Name should contain at least one sequence of charachters and a max of 2 separated by single space")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}