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
        private string[] validDirections = new string[] { "north", "south", "east", "west" };
        private readonly Command.Command _moveCommand;
        private readonly Command.Command _leftCommand;
        private readonly Command.Command _rightCommand;
        private readonly Command.Command _reportCommand;

        public CommandProcessor(int rows, int columns)
        {

            if (rows < 0)
            {
                throw new Exception($"Table row value should be positive {rows}");
            }

            if (columns < 0)
            {
                throw new Exception($"Table column value should be positive {columns}");
            }

            _toyRobot = new ToyRobot(rows, columns);
            this._moveCommand = new MoveCommand(this._toyRobot);
            this._leftCommand = new LeftCommand(this._toyRobot);
            this._rightCommand = new RightCommand(this._toyRobot);
            this._reportCommand = new ReportCommand(this._toyRobot);
        }


        private void ValidateFace(string facing)
        {
            var validMove = Array.Find(validDirections, vm => vm.Equals(facing, StringComparison.OrdinalIgnoreCase));
            if (validMove == null)
            {
                throw new Exception("Provide valid face: North,East,West,South");
            }
        }

        private bool ValidatePlaceArguments(string[] args)
        {
            if (args != null && args.Length == 4)
            {

                try
                {
                    int.Parse(args[1]);
                    int.Parse(args[2]);

                }
                catch 
                {
                    throw new Exception("provide valid numeric value");

                }
                this.ValidateFace(args[3]);
                return true;

            }
            throw new Exception("Invalid place command: Use E.g. place 0 0 East");
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

                        // if (int.TryParse(args[1], out int x) && int.TryParse(args[2], out int y))
                        if (this.ValidatePlaceArguments(args))
                        {
                            report = new PlaceCommand(this._toyRobot, new Point(int.Parse(args[1]), int.Parse(args[2])), args[3]).Execute();
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
                        throw new Exception("Not a valid command");
                }
            }

            return report;
        }
    }
}
