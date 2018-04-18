using System;
using System.Collections.Generic;
using System.Text;
using Toy.Robot.Command;
using Toy.Robot.Model;

namespace Toy.Robot
{
    
    public class CommandProcessor
    {
        private readonly IToyRobot _toyRobot;
        private readonly Command.Command _moveCommand;
        private readonly Command.Command _leftCommand;
        private readonly Command.Command _rightCommand;
        private readonly Command.Command _reportCommand;

        public CommandProcessor(int rows, int columns)
        {
            _toyRobot = new ToyRobot(rows, columns);
            this._moveCommand = new MoveCommand(this._toyRobot);
            this._leftCommand = new LeftCommand(this._toyRobot);
            this._rightCommand = new RightCommand(this._toyRobot);
            this._reportCommand = new ReportCommand(this._toyRobot);
        }

        public Report Run(string[] args)
        {
            Report report = null;
            if (args != null && args.Length > 0)
            {
                string command = args[0];

                switch (command.ToLower())
                {
                    case "place":

                        if (int.TryParse(args[1], out int x) && int.TryParse(args[2], out int y))
                        {
                            report = new PlaceCommand(this._toyRobot, new Point(x, y), args[3]).Execute();
                        }
                        break;

                    case "move":
                        report = this._moveCommand.Execute();
                        break;

                    case "left":
                        report = this._leftCommand.Execute();
                        break;

                    case "right":
                        report = this._rightCommand.Execute();
                        break;

                    case "report":
                        report = this._reportCommand.Execute();
                        break;

                    default:
                        Console.WriteLine("Not a valid command");
                        break;
                }
            }

            return report;
        }
    }
}
