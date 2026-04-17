using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoGranja
{
    internal class Animal
    {
        public string Name;
        public int ProductValue;
        public int DaysLeft;
        public int MaxDays;

        public Animal(string name, int productValue, int daysLeft)
        {
            Name = name;
            ProductValue = productValue;
            DaysLeft = daysLeft;
            MaxDays = daysLeft;
        }
    }
}
