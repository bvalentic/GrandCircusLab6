using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            /* enter number of sides for a pair of dice
             * prompt user to roll
             * roll two n-sided dice, print result, ask to continue
             */

            
            string cont = "y";
            

            Console.WriteLine("Roll the dice! Luck be a lady tonight!\n");

            while (cont == "y" || cont == "yes")
            {
                Console.Write("How many sides will the two dice have? ");
                try
                {
                    int dieSide = int.Parse(Console.ReadLine()); //this gets the upper bound for the rng
                    if (dieSide <= 1)
                    {
                        Console.Write("There can't be less than 2 sides on a die.\n" +
                            "Although, really, why are you using anything besides six sides? \n" +
                            "Playing D&D or something? Anyway, wanna try again? (y/n) ");

                    }
                    else
                    {
                        RollDice(dieSide);
                        Console.Write("\nLet it ride? (y/n) ");
                    }
                }
                catch (Exception)
                {
                    Console.Write("I don't know what that number is. Wanna try again? (y/n) ");
                }
                
                cont = Console.ReadLine().ToLower();
            }
            Console.WriteLine("\nThe house always wins!");
            Console.ReadKey();

            
        }

        public static void RollDice(int dieSide)
        {
            //generates two n-sided dice and rolls them
            Random rnd = new Random(); //rnd is object in class Random
            Console.WriteLine(dieSide + " sides. Nice! Let's roll!");
            Console.Write("Ready? (y/n) ");//prompts to roll
            string rollYes = Console.ReadLine();
            if (rollYes.ToLower() == "y" || rollYes.ToLower() == "yes")
            {
                int die1 = rnd.Next(1, dieSide + 1); //will generate a number between 1 and dieSide
                int die2 = rnd.Next(1, dieSide + 1);
                Console.WriteLine("The results are:\n");
                DiceRollerApp(die1, die2);
            }

        }

        public static void DiceRollerApp(int die1, int die2)
        {
            //rolls two dice and gives special messages based on results of dice roll
            Console.WriteLine(die1 + " and " + die2 + ", for a total of " + (die1+die2)); //prints results and sum of latest roll
            if (die1 == die2)
            {
                if (die1 == 1)
                {
                    Console.WriteLine("Snake eyes!");//result is 1 and 1
                }
                else if (die1 == 6)
                {
                    Console.WriteLine("Boxcars!");//result is 6 and 6
                }
                //else Console.WriteLine("Doubles!");
                else Console.WriteLine(die1 + " the hard way");//result is any pair of doubles between 2 and 5

            }
            if (die1 + die2 == 7)
            {
                Console.WriteLine("Lucky seven!");
            }
            if ((die1 + die2 == 2) || (die1 + die2 == 3) || (die1 + die2 == 12))
            {
                Console.WriteLine("Craps!");
            }
        }
    }
}
