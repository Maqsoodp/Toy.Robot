using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Toy.Robot.Command;

namespace Toy.Robot.UnitTest
{
    [TestFixture]
    internal class TestMoveScenarios : ToyRobotTest
    {
        [TestCase(5, 5, 0, 0, "North", 0, 0)]
        [TestCase(5, 5, 0, 0, "East", 0, 1)]
        [TestCase(5, 5, 0, 0, "West", 0, 0)]
        [TestCase(5, 5, 0, 0, "South", 1, 0)]
        public void TestMove(int tableSizeX, int tableSizeY, int x, int y, string face, int expectedX, int expectedY)
        {
            // Arrange
            this._toyRobot = new ToyRobot(tableSizeX, tableSizeY);
            this._toyRobot.Place(new Point(x, y), face);

            // Act
            var report = this._toyRobot.Move();

            Assert.NotNull(report);
            Assert.NotNull(report.Point);
            Assert.AreEqual(report.Point.x, expectedX);
            Assert.AreEqual(report.Point.y, expectedY);
            Assert.AreEqual(report.Face, face);
        }

    }
}
