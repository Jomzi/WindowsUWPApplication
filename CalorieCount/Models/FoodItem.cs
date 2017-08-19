using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCount.Models
{
    /* FoodItem Class, Used to create Food Items */
    class FoodItem
    {
        public string foodName { get; set; }
        public double calorieAmount { get; set; }
        public DateTime dateAdded { get; set; }
        public override string ToString()
        {
            return "" + foodName + "\n" + calorieAmount + "\n" + dateAdded.ToString() + "\n";
        }
    }
}
