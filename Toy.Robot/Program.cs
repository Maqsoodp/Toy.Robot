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
                Console.WriteLine("Toy Robot instructions -");
                Console.WriteLine("Provide size of the table by passing rows and columns E.g. 5, 5");
                Console.WriteLine("Place toy by provide x y position along with facing E.g.  place 0 0 North");
                Console.WriteLine("Give Commands -  Move Left Right Report Exit");
            }

            var size = true;
            CommandProcessor commandProcessor = null;
            while (size)
            {
                Console.WriteLine("Please provide size of the Table E.g. 5, 5");
                var sizeInfo = Console.ReadLine();
                if (sizeInfo != null)
                {
                    args = sizeInfo.Trim().Split(',');
                    if (args != null && args.Length > 0)
                    {
                        try
                        {
                            commandProcessor = new CommandProcessor(int.Parse(args[0]), int.Parse(args[1]));
                            size = false;
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                }
            }

            Console.WriteLine("Table activated");
            Console.WriteLine("Place the toy using place command. E.g. place 0 0 North");
            Console.WriteLine("To continue playing, provide commands - Move Left Right Report Exit");

            if (commandProcessor != null)
            {
                var play = true;
                while (play)
                {
                    var commands = Console.ReadLine();
                    if (commands != null && commands.Length > 0)
                    {

                        if (commands.Trim().ToLower() == "exit")
                        {
                            play = false;
                        }
                        else
                        {
                            try
                            {
                                commandProcessor.Run(commands.Trim().Split(' '));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                           
                        }
                    }

                }
            }
        }
    }
}
