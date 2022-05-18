using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSlutuppgift
{
    /// <summary>
    /// the boss enemy
    /// </summary>
    
    internal class Boss : Enemy
    {
        public Boss() : base("The Soul Crusher")
        {
            //higher value for health
            Health = 150;

        }
    }
}
