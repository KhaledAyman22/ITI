using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_EF01.Entities
{
    /// <summary>
    /// 2. Data annotation
    /// </summary>
    [Table("LibraryBranches")]
    public class Branch
    {
        [Key]
        public int BID { get; set; }
        [MaxLength(40)]
        public string City { get; set; } = string.Empty;
        [MaxLength(10)]
        [Required]
        public string? ZipCode { get; set; }
        [Column(TypeName ="smallint")]
        public int OpenHour { get; set; }

        public virtual ICollection<Title> Titles { get; set; } = new HashSet<Title>();
    }
}
