using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot
{
    enum Command
    {
        Place,
        Move,
        Left,
        Right
    }
    internal class CommandProcessor
    {
        internal static Command Parse(string[] args)
        {
            string command = args[0];
            switch (command.ToLower())
            {
                case "place":
                    return Command.Place;
                case "move":
                    return Command.Move;
                case "left":
                    return Command.Left;
                case "right":
                    return Command.Right;

            }
            return Command.Left;
        }
    }
}
