using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Robot.Command
{
    public class ToyRobot : IToyRobot
    {

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

        }

        public ToyRobot(int rows, int columns)
        {
            this.sizeX = rows;
            this.sizeY = columns;
            this.Prepare(rows, columns);
            this.report = new Report();
        }

        public Report Place(Point point, string face)
        {
            if (point == null)
            {
                point = new Point();
            }

            if (string.IsNullOrWhiteSpace(face))
            {
                face = "North";
            }

            if (point.x < 0 || point.x > this.sizeX - 1)
            {
                throw new Exception($"Toy robot should be placed with in the table {sizeX} {sizeY}");
            }

            if (point.y < 0 || point.y > this.sizeY - 1)
            {
                throw new Exception($"Toy robot should be placed with in the table {sizeX} {sizeY}");
            }

            this.report = new Report(point, face);
            return this.report;
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

        public Report Move()
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

            return this.report;

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
        public Report Left()
        {
            var currentFace = this.report.Face;
            this.report.Face = this.GetNextValueOnRotateLeft(currentFace);
            return this.report;
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

        public Report Right()
        {
            var currentFace = this.report.Face;
            this.report.Face = this.GetNextValueOnRotateRight(currentFace);
            return this.report;
        }

        public Report Report()
        {
            var point = this.report.Point;
            Console.WriteLine($"{point.x} {point.y} {this.report.Face}");
            return this.report;
        }
    }
}
