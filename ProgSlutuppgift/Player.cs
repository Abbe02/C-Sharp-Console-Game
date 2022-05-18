using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSlutuppgift
{
    /// <summary>
    /// Class for the playable character.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// the health value of the player
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// the name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// determines if this player is dead
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Determines if the player is guarding.
        /// </summary>
        public bool IsGuarding { get; set; }   
        public Player()
        {
            //sets the health value to 100
            Health = 100;

            /// <summary>
            /// this gets called when the player is hit
            /// </summary>
            /// <param name="hit_value">the amount of damage the player will take</param>
         
            }
        public int GetsHit(int hit_value)
        {
            //Check if the player was guarding.
            if (IsGuarding)
            {
                //Write out that the player guarded the attack.
                Console.WriteLine(Name + " guarded the blow and was unharmed!");
            }
            else
            {
                //substract the hit value from the health
                Health = Health - hit_value;

                //write out that the player got hit
                Console.WriteLine(Name + " was hit for " + hit_value + " damage! You now have " + Health + " remaining");

                //remove the guard
                IsGuarding = false;
            }
            
            

            //check if the player is dead
            if (Health <= 0)
            {
                Die();
            }

            //return the health from this function
            return Health;
        } 
        
        /// <summary>
        /// heals the player with the amount to heal
        /// </summary>
        /// <param name="amount_to_heal">the number amount to heal the player</param>
        public void Heal(int amount_to_heal)
        {
            //heal the player by adding the amount to heal to the player's health
            Health = (Health + amount_to_heal > 100) ? 100 : (Health + amount_to_heal);

            //Let the player know his new health value.
            Console.WriteLine(Name + " has healed " + amount_to_heal + " health. You now have " + Health + " health remaining");
        }
           /// <summary>
           /// called when the enemy is supposed to die
           /// </summary>
        private void Die()
        {
            //write to the console that the enemy is dead
            Console.WriteLine(Name + " has died!");

            //set the bollean that this enemy has died
            IsDead = true;
        }
    }

}
