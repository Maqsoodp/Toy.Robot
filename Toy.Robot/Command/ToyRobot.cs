using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class ToyRobot : IToyRobot
    {

        //private IDictionary<Point, string[]> northRowWhiteList;
        //private IDictionary<Point, string[]> southRowWhiteList;
        //private IDictionary<Point, string[]> eastColumnWhiteList;
        //private IDictionary<Point, string[]> westColumnWhiteList;
        // private int[,] results = new int[5, 5];

        private int sizeX = 5;
        private int sizeY = 5;
        private IDictionary<Point, string[]> circularWhiteList;
        private Report report;

        private void Prepare(int rows, int columns)
        {
            circularWhiteList = new Dictionary<Point, string[]>(new PointEqualityComparer());

            circularWhiteList.Add(new Point(0, 0), new string[2] { "South", "East" });
            for (var j = 1; j < columns - 1; j++)
            {
                circularWhiteList.Add(new Point(0, j), new string[3] { "South", "East", "West" });
            }
            circularWhiteList.Add(new Point(0, columns - 1), new string[2] { "South", "West" });

            circularWhiteList.Add(new Point(rows - 1, 0), new string[2] { "North", "East" });
            for (var j = 1; j < columns - 1; j++)
            {
                circularWhiteList.Add(new Point(rows - 1, j), new string[3] { "North", "East", "West" });
            }
            circularWhiteList.Add(new Point(rows - 1, columns - 1), new string[2] { "North", "West" });

            for (var i = 1; i < rows - 1; i++)
            {
                circularWhiteList.Add(new Point(i, 0), new string[3] { "North", "East", "South" });
            }

            for (var i = 1; i < rows - 1; i++)
            {
                circularWhiteList.Add(new Point(i, columns - 1), new string[3] { "North", "West", "South" });
            }


            //northRowWhiteList = new Dictionary<Point, string[]>();
            //northRowWhiteList.Add(new Point(0, 0), new string[2] { "South", "East" });
            //northRowWhiteList.Add(new Point(0, 1), new string[3] { "South", "East", "West" });
            //northRowWhiteList.Add(new Point(0, 2), new string[3] { "South", "East", "West" });
            //northRowWhiteList.Add(new Point(0, 3), new string[3] { "South", "East", "West" });
            //northRowWhiteList.Add(new Point(0, 4), new string[2] { "South", "West" });

            //southRowWhiteList = new Dictionary<Point, string[]>();
            //southRowWhiteList.Add(new Point(4, 0), new string[2] { "North", "East" });
            //southRowWhiteList.Add(new Point(4, 1), new string[3] { "North", "East", "West" });
            //southRowWhiteList.Add(new Point(4, 2), new string[3] { "North", "East", "West" });
            //southRowWhiteList.Add(new Point(4, 3), new string[3] { "North", "East", "West" });
            //southRowWhiteList.Add(new Point(4, 4), new string[2] { "North", "West" });

            //eastColumnWhiteList = new Dictionary<Point, string[]>();
            //// eastColumnWhiteList.Add(new Point(0, 0), new string[2] { "South", "East" });
            //eastColumnWhiteList.Add(new Point(1, 0), new string[3] { "North", "East", "South" });
            //eastColumnWhiteList.Add(new Point(2, 0), new string[3] { "North", "East", "South" });
            //eastColumnWhiteList.Add(new Point(3, 0), new string[3] { "North", "East", "South" });
            ////eastColumnWhiteList.Add(new Point(4, 0), new string[2] { "North", "East" });

            //westColumnWhiteList = new Dictionary<Point, string[]>();
            //// westColumnWhiteList.Add(new Point(0, 4), new string[2] { "South", "West" });
            //westColumnWhiteList.Add(new Point(1, 4), new string[3] { "North", "West", "South" });
            //westColumnWhiteList.Add(new Point(2, 4), new string[3] { "North", "West", "South" });
            //westColumnWhiteList.Add(new Point(3, 4), new string[3] { "North", "West", "South" });
            ////westColumnWhiteList.Add(new Point(4, 4), new string[2] { "North", "West" });

        }

        public ToyRobot(int rows, int columns)
        {
            this.sizeX = rows;
            this.sizeY = columns;
            this.Prepare(rows, columns);
            this.report = new Report();
        }

        public void Place(Point point, string face)
        {
            this.report = new Report(point, face);
        }

        private void MoveEast()
        {
            this.report.Point.y += 1;
        }
        private void MoveWest()
        {
            this.report.Point.y -= 1;
        }
        private void MoveNorth()
        {
            this.report.Point.x -= 1;
        }
        private void MoveSouth()
        {
            this.report.Point.x += 1;
        }

        private void CallMove()
        {
            var currentFace = this.report.Face;
            switch (currentFace)
            {
                case "East": this.MoveEast(); break;
                case "West": this.MoveWest(); break;
                case "North": this.MoveNorth(); break;
                case "South": this.MoveSouth(); break;
            }

        }

        public void Move()
        {
            var currentFace = this.report.Face;
            var point = this.report.Point;

            if (this.circularWhiteList.TryGetValue(this.report.Point, out var possibleDirection))
            {
                var validMove = Array.Find(possibleDirection, p => p.Equals(currentFace));
                if (validMove != null && validMove.Length > 0)
                {
                    this.CallMove();
                }
            }
            else if (point.x < this.sizeX && point.y < this.sizeY)
            {
                this.CallMove();
            }

        }

        private string GetNextValueOnRotateLeft(string currentFace)
        {

            switch (currentFace)
            {
                case "North": return "West";
                case "East": return "North";
                case "West": return "South";
                case "South": return "East";
                default: return currentFace;
            }
        }
        public void Left()
        {
            var currentFace = this.report.Face;
            this.report.Face = this.GetNextValueOnRotateLeft(currentFace);
        }

        private string GetNextValueOnRotateRight(string currentFace)
        {
            switch (currentFace)
            {
                case "North": return "East";
                case "East": return "South";
                case "West": return "North";
                case "South": return "West";
                default: return currentFace;
            }
        }

        public void Right()
        {
            var currentFace = this.report.Face;
            this.report.Face = this.GetNextValueOnRotateRight(currentFace);
        }

        public void Report()
        {
            var point = this.report.Point;
            Console.WriteLine($"{point.x} {point.y} {this.report.Face}");
        }
    }
}
