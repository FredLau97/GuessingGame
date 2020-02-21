using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main()
        {
            Game Game = new Game();
            Game.StartGame();

            while(Game.endPrompt != "r" || Game.endPrompt != "q")
            {
                Console.WriteLine($"\nType 'r' to try again" +
                $"\nType 'q' to quit the game");
                Game.endPrompt = Console.ReadLine();
                Game.endPrompt.ToLower();

                if (Game.endPrompt == "r")
                {
                    Console.Clear();
                    Main();
                }
                else if (Game.endPrompt == "q")
                    Environment.Exit(0);
                else
                    Console.WriteLine("\nNot so good at following instructions, are we..?");
            }
        }
    }
}
