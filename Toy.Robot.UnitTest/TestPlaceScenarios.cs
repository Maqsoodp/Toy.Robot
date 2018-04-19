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
    internal class TestPlaceScenarios : ToyRobotTest
    {

        [TestCase(5, 5, 0, 0, "North", 0, 0)]
        [TestCase(5, 5, 0, 4, "East", 0, 4)]
        [TestCase(5, 5, 2, 2, "South", 2, 2)]
        [TestCase(5, 5, 4, 4, "West", 4, 4)]
        [TestCase(5, 5, 4, 0, "North", 4, 0)]
        public void TestPlace_Happy(int tableSizeX, int tableSizeY, int x, int y, string face, int expectedX, int expectedY)
        {
            // Arrange
            this._toyRobot = new ToyRobot(tableSizeX, tableSizeY);

            // Act
            var report = this._toyRobot.Place(new Point(x, y), face);

            Assert.NotNull(report);
            Assert.NotNull(report.Point);
            Assert.AreEqual(report.Point.x, expectedX);
            Assert.AreEqual(report.Point.y, expectedY);
            Assert.AreEqual(report.Face, face);
        }

        [TestCase(5, 5, -1, 0, "North")]
        [TestCase(5, 5, -1, -1, "North")]
        [TestCase(5, 5, 0, -1, "North")]
        [TestCase(5, 5, 20, 12, "North")]
        public void TestPlace_Negative(int tableSizeX, int tableSizeY, int x, int y, string face)
        {
            // Arrange
            this._toyRobot = new ToyRobot(tableSizeX, tableSizeY);

            // Act
            var ex = Assert.Throws
                    <Exception>(
                        () => this._toyRobot.Place(new Point(x, y), face)
                    );

            // Assert

            Assert.That(ex, Is.Not.Null);
            Assert.AreEqual(ex.Message, $"Toy robot should be placed with in the table {tableSizeX} {tableSizeY}");

        }

        [Test]
        public void TestPlace_Null()
        {
            // Arrange
            this._toyRobot = new ToyRobot(5, 5);

            // Act
            var report = this._toyRobot.Place(null, "");

            Assert.NotNull(report);
            Assert.NotNull(report.Point);
            Assert.AreEqual(report.Point.x, 0);
            Assert.AreEqual(report.Point.y, 0);
            Assert.AreEqual(report.Face, "NORTH");

        }

    }
}
