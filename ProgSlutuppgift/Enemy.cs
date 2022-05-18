using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSlutuppgift
{
    /// <summary>
    /// base elements of an enemy
    /// </summary>
    internal class Enemy
    {
        /// <summary>
        /// the health value of the enemy
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// the name of the enmey
        /// </summary>
        public string Name { get; set; }
       /// <summary>
       /// determines if this enemy is dead
       /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="name">name of choice for the enemy</param>
        public Enemy(string name)
        {
            //set the enemies' health
            Health = 100;

            //set the enemy name
            Name = name;
        }

        /// <summary>
        /// get's called when the enemy is hit
        /// </summary>
        /// <param name="hit_value">the amount of damage the enemy takes</param>
        public void GetsHit(int hit_value)
        {
            //substract the hit value from the health
            Health = Health - hit_value;

            //write out that the enemy got hit
            Console.WriteLine(Name + " was hit for " + hit_value + " damage! He now has " + Health + " health remaining");
            
            //check if the enemy is dead
            if (Health <= 0)
            {
                //the enemy is dead
                Die();
            }
        }
        /// <summary>
        /// called when the enemy is supposed to die
        /// </summary>
        private void Die()
        {
            //write to the console that the enemy is dead
            Console.WriteLine(Name + " has died!");

            //set the boolean that this enemy has died
            IsDead = true;
        }
    }
}
