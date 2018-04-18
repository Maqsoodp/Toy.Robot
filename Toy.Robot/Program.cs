using System;
using System.Collections;
using System.Collections.Generic;
using Toy.Robot.Command;

namespace Toy.Robot
{
    
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 0)
            {
                Console.WriteLine("Play Toy Robot with following commands -");
                Console.WriteLine("Decide size of the Table by passing rows and columns E.g. 5 5");
                Console.WriteLine("Place Toy at any x y position with Toy facing E.g.  0 0 North");
                Console.WriteLine("Give Commands -  Move Left Right Report ");
            }

            args = new string[] { "5", "5" };
            var processor = new CommandProcessor(int.Parse(args[0]), int.Parse(args[1]));

            var play = true;
            while(play)
            {
                var commands =  Console.ReadLine();
                if(commands != null && commands.Length > 0)
                {

                    if (commands.ToLower() == "exit")
                    {
                        play = false;
                    }
                    else
                    {
                        processor.Run(commands.Split(" "));
                    }
                }
                
            }
            
        }
    }
}
