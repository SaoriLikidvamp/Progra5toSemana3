using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoGranja
{
    internal class Farm
    {
        public int Money = 300;
        public int Space = 4;

        public List<string> Seeds = new List<string>();

        public List<Plant> Plants = new List<Plant>();

        public List<Animal> Animals = new List<Animal>();

    }
}
