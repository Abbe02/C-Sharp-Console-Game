using System;

namespace ProgSlutuppgift 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //define the list that is going to keep the track of the game history
            List<string> gameHistory = new List<string>();
            
            //create and store random class
            Random random = new Random();
            
            
            //output 
            Console.WriteLine("Your name?");

            //create the player character
            Player player = new Player()
            {
                Name = Console.ReadLine()
            };

            //outputs player's name
            Console.Write("Your name is, " + player.Name + ".\n");

            //variable that tracks the first enemy
            Enemy firstEnemy = new Enemy("Skeleton Enemy");

            //perform the battle game loop
            GameLoop(firstEnemy, random, player, 5, 20, gameHistory);

            //check if the player was the one who died
            if (!player.IsDead)
            {
                //create the boss character
                Boss boss = new Boss();

                //perform the battle game loop
                GameLoop(boss, random, player, 40, 10, gameHistory);

                // check if the player was the one who died
            if (!player.IsDead)
                {
                    //the player survived and won the game
                    Console.WriteLine("Great " +player.Name + ", you survived and defeated all the enemies and saves the kingdom! Unfortunately, the princess is in another castle... ");
                }
                else
                {
                    GameOver();
                }
            }
            Console.WriteLine("\n\nThis is the history of the game.\n\n");
            
            foreach (var history in gameHistory)
            {
                Console.WriteLine(history);
            }

        }

        /// <summary>
        /// writes out what happens when the game is over
        /// </summary>
        private static void GameOver()
        {
            //the player is dead, let the user know the game is over
            Console.WriteLine("You died, game over!");
        }

        /// <summary>
        /// the main game loop that allows the player to attack an enemy
        /// </summary>
        /// <param name="enemy">the enemy that the player will attack</param>
        /// <param name="random">the random number generator we will use to generate random numbers</param>
        /// <param name="player">the player that we are playing as</param>
        /// <param name="max_attack_power">the max attack power of the enemy</param>
        /// <param name="max_player_attack_power">the max attack power of the player</param>
        /// <param name="gameHistoryList">the list that contains the game history</param>
        private static void GameLoop(Enemy enemy, Random random, Player player, int max_attack_power, int max_player_attack_power, List<string> gameHistoryList)
        {
            string initialText = player.Name + ", you have encountered " + enemy.Name + "!";
            string attackText = null;
            string enemyAttackText = null;
            
            Console.WriteLine(initialText);

            gameHistoryList.Add(initialText);

            //while the first enemy and player is not dead, repeat the playable cycle
            while (!enemy.IsDead && !player.IsDead)
            {
                //write out to the screen your options
                Console.WriteLine("What would you like to do?\n\n1.Single Attack\n2.Double Attack\n3.Defend\n4.Heal");
                //store what action the player chooses
                string playersAction = Console.ReadLine();

                //check what action player took
                switch (playersAction)
                {
                    case "1":
                        attackText = "You go for a single attack on " + enemy.Name + "!";

                        Console.WriteLine(attackText);

                        gameHistoryList.Add(attackText);

                        //apply the attack damage to the enemy 
                        enemy.GetsHit(random.Next(1, max_attack_power));

                        break;
                    case "2":
                        attackText = "You go for a double attack on " + enemy.Name + "!";

                        Console.WriteLine(attackText);
                        
                        gameHistoryList.Add(attackText);

                        for (int i = 0; i < 2; i++) //for loop
                        {
                            //attack damage enemy suffers
                            enemy.GetsHit(random.Next(1, max_attack_power));

                            //check if the enemy is dead
                            if (enemy.IsDead) 
                            {
                                //break out of the for loop
                                break;
                            }
                            
                        }
                        break;
                    case "3":
                        attackText = "You defend!";

                        Console.WriteLine(attackText);

                        gameHistoryList.Add(attackText);

                        //set that the player is guading
                        player.IsGuarding = true;

                        break;
                    case "4":
                        attackText = "You healed!";

                        Console.WriteLine(attackText);

                        gameHistoryList.Add(attackText);

                        //heal the player a random amount
                        player.Heal(random.Next(1, 15));

                        break;
                    default:
                        Console.WriteLine("You made a different choice.");
                        break;
                }

                //make sure the enemy is not dead 
                if (!enemy.IsDead)
                {

                    //have the enemy attack the player
                    enemyAttackText = "The enemy attacked the player and the player has " + player.GetsHit(random.Next(1, max_attack_power)) + " health remaining.";

                    //write out that the enemy attacked
                    gameHistoryList.Add(enemyAttackText);
                }


            }
        }
    }
}