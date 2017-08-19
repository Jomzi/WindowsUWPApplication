using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCount.Models
{
    /* Settings Class, used to save and load current settings to a file */
    class Settings
    {
        public string name { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return "" + name + "\n" + age;
        }
    }
}
