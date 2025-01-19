using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Host
{
    internal class Host
    {
        public bool Infected { get; set; }
        public int Level { get; set; }
        public int Speed { get; set; }

        public Host(int level)
        {
            Random random = new();

            Infected = false;
            Level = level;
            Speed = random.Next(1, 5);
        }
    }
}
