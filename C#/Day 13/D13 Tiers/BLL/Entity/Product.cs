using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Product:EntityBase
    {
		public int ProductID { get; set; }
		string productName;
		public string ProductName { 
			get => productName;
			set
			{
				if ( value != productName)
				{
					if (this.State != EntityState.Added)
						this.State = EntityState.Changed;
					productName = value;
				}
			}
		}
		public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
		public string QuantityPerUnit { get; set; }
		public decimal? UnitPrice { get; set; }
		public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
    }
}
