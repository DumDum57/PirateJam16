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
        internal HostManager Manager { get; }
        internal bool RangeRendered { get; set; }

        internal Host(int level, HostManager manager)
        {
            Random random = new();

            Infected = false;
            Level = level;
            Speed = random.Next(1, 5);
            Manager = manager;
            RangeRendered = false;
        }
    }
}
