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
    internal class TestLeftScenarios : ToyRobotTest
    {
        [TestCase(5, 5, 0, 0, "North", "West")]
        [TestCase(5, 5, 0, 0, "West", "South")]
        [TestCase(5, 5, 0, 0, "South", "East")]
        [TestCase(5, 5, 0, 0, "East", "North")]
        public void TestLeft(int tableSizeX, int tableSizeY, int x, int y, string face, string expectedFace)
        {
            // Arrange
            this._toyRobot = new ToyRobot(tableSizeX, tableSizeY);
            this._toyRobot.Place(new Point(x, y), face);

            // Act
            var report = this._toyRobot.Left();

            Assert.AreEqual(report.Point.x, x);
            Assert.AreEqual(report.Point.y, y);
            Assert.AreEqual(report.Face, expectedFace.ToUpper());

        }
    }
}
