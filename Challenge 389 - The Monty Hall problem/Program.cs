using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_389___The_Monty_Hall_problem
{
    internal class Program
    {
        public static Random rdn = new Random();
        private const int NbTry = 10000;

        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/n94io8/20210510_challenge_389_easy_the_monty_hall_problem/

            Console.WriteLine("Alice : " + CalculateAliceSucessRate() + "%");
            Console.WriteLine("Bob  : " + CalculateBobSucessRate() + "%");
            Console.WriteLine("Carol  : " + CalculateCarolSucessRate() + "%");
            Console.WriteLine("Dave  : " + CalculateDaveSucessRate() + "%");
            Console.WriteLine("Eren  : " + CalculateErinSucessRate() + "%");
            Console.WriteLine("Frank  : " + CalculateFrankSucessRate() + "%");
            Console.WriteLine("Gina  : " + CalculateGinaSucessRate() + "%");
        }

        private static double CalculateAliceSucessRate()
        {
            //Alice chooses door #1 in step 2, and always sticks with door #1 in step 4.

            int successRate = 0;

            for (int i = 0; i < NbTry; i++)
                if (rdn.Next(1, 4) == 1)
                    successRate++;
            
            return ((double)successRate * 100) / NbTry;
        }
        
        private static double CalculateGinaSucessRate()
        {
            // Gina always uses either Alice's or Bob's strategy. She remembers whether her previous strategy worked and changes it accordingly. On her first game, she uses Alice's strategy. Thereafter, if she won the previous game, then she sticks with the same strategy as the previous game. If she lost the previous game, then she switches (Alice to Bob or Bob to Alice).
            
            int successRate = 0;
            bool aliceStrategyWorked = true;

            for (int i = 0; i < NbTry; i++)
            {
                if(aliceStrategyWorked)
                {
                    if (rdn.Next(1, 4) == 1)
                        successRate++;
                    else
                        aliceStrategyWorked = false;
                }
                else
                {
                    if (rdn.Next(1, 4) != 1)
                        successRate++;
                    else
                        aliceStrategyWorked = true;
                }
            }

            return ((double)successRate * 100) / NbTry;
        }

        private static double CalculateBobSucessRate()
        {
            //Bob chooses door #1 in step 2, and always switches to the other closed door in step 4.

            int successRate = 0;

            for (int i = 0; i < NbTry; i++)           
                if (rdn.Next(1, 4) != 1)
                    successRate++;       

            return ((double)successRate * 100) / NbTry;
        }
        
        private static double CalculateDaveSucessRate()
        {
            //Dave chooses randomly in step 2, and always sticks with his door in step 4.

            int successRate = 0;

            for (int i = 0; i < NbTry; i++)           
                if (rdn.Next(1, 4) == rdn.Next(1, 4))
                    successRate++;       

            return ((double)successRate * 100) / NbTry;
        }
        
        private static double CalculateCarolSucessRate()
        {
            // Carol chooses randomly from the available options in both step 2 and step 4.

            int successRate = 0;

            for (int i = 0; i < NbTry; i++)
            {

                int price = rdn.Next(1, 4);
                int chosenDoor = rdn.Next(1, 4);

                int doorBanished = price;



                while (doorBanished == price || doorBanished == chosenDoor)
                    doorBanished = rdn.Next(1, 4);

                chosenDoor = doorBanished;

                while (chosenDoor == doorBanished)               
                    chosenDoor = rdn.Next(1, 4);

                if (chosenDoor == price)
                    successRate++;
            }

            return ((double)successRate * 100) / NbTry;
        }
        
        private static double CalculateErinSucessRate()
        {
            // Erin chooses randomly in step 2, and always switches in step 4.

            int successRate = 0;

            for (int i = 0; i < NbTry; i++)
            {

                int price = rdn.Next(1, 4);
                int chosenDoor = rdn.Next(1, 4);

                int doorBanished = price;

                while (doorBanished == price || doorBanished == chosenDoor)
                    doorBanished = rdn.Next(1, 4);

                int temp = chosenDoor;

                while (chosenDoor == temp || chosenDoor == doorBanished)               
                    chosenDoor = rdn.Next(1, 4);

                if (chosenDoor == price)
                    successRate++;
            }

            return ((double)successRate * 100) / NbTry;
        }

        private static double CalculateFrankSucessRate()
        {
            // Frank chooses door #1 in step 2, and switches to door #2 if available in step 4. If door #2 is not available because it was opened, then he stays with door #1.

            int successRate = 0;

            for (int i = 0; i < NbTry; i++)
            {

                int price = rdn.Next(1, 4);
                int chosenDoor = 1;

                int doorBanished = price;

                while (doorBanished == price || doorBanished == chosenDoor)
                    doorBanished = rdn.Next(1, 4);

                chosenDoor = doorBanished == 2 ? 1 : 2;

                if (chosenDoor == price)
                    successRate++;
            }

            return ((double)successRate * 100) / NbTry;
        }


    }
}
