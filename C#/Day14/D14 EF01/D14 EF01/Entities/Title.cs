using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_EF01.Entities
{
    /// <summary>
    /// 4 Mapping Ways
    /// 1. EF Convension (Default)
    /// 2. Attributes [Mapping Attribute] , Data Annotations
    /// 3. Fluent API (onModelCreating (ModelBuilder){})
    /// 4. Configuration Classes
    /// </summary>
    /// using EF Convensions
    public class Title
    {
        ///public Numeric Attribute , ID or EntityNameID ::PK , identity
        public int ID { get; set; }
        
        ///Non Nullable Reference Type
        public /*required*/ string AuthorName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
        ///Nullable Value Type , Nullable<Decimal>
        public decimal? PromotionalPrice { get; set; }

        ///Nullable Refrence Type
        public string? Forward { get; set; }

        public virtual Branch? Branch { get; set; }


        //public Title(int iD, string authorName, decimal price, string? forward)
        //{
        //    ID = iD;
        //    AuthorName = authorName;
        //    Price = price;
        //    Forward = forward;
        //}
    }
}
