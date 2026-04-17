using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoGranja
{
    internal class Plant
    {
        public string Name;
        public int DaysLeft;
        public int SellValue;

        public Plant(string name, int daysLeft, int sellValue)
        {
            Name = name;
            DaysLeft = daysLeft;
            SellValue = sellValue;
        }
    }
}
