using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UI.MVVM.ViewModel
{
    public class FoodMenuViewModel
    {
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        public bool Cleaning { get; set; }
        public bool Towels { get; set; }
        public bool SweetSurprise { get; set; }

        public Dictionary<string, string> ProcessInput()
        {
            return new()
            {
                { "Breakfast", Breakfast.ToString() },
                { "Lunch", Lunch.ToString() },
                { "Dinner", Dinner.ToString() },
                { "Cleaning", Cleaning.ToString() },
                { "Towels", Towels.ToString() },
                { "SweetSurprise", SweetSurprise.ToString() }
            };
        }
    }
}
