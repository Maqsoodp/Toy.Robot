using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Toy.Robot.UnitTest
{
    [TestFixture]
    public class CommandProcessorTest
    {
        [TestCase(5, 5, "place 0 0 North, right, move, left, report", 0, 1, "North")]
        [TestCase(10, 15, "place 9 14 North, move, left, move, left, move, report", 9, 13, "South")]
        [TestCase(15, 15, "place 5 5 North, move, right, move, left, report", 4, 6, "North")]
        public void TestCommandProcessor(int tableSizeX, int tableSizeY, string commands, int expectedX, int expectedY, string expectedFace)
        {
            // Arrange
            var _commandProcessor = new CommandProcessor(tableSizeX, tableSizeY);
            var combinationList = commands.Split(',');

            // Act
            Report report = null;
            foreach (var command in combinationList)
            {
                report = _commandProcessor.Run(command.Trim().Split(' '));
            }

            Assert.NotNull(report);
            Assert.NotNull(report.Point);
            Assert.AreEqual(report.Point.x, expectedX);
            Assert.AreEqual(report.Point.y, expectedY);
            Assert.AreEqual(report.Face, expectedFace);
        }
    }
}
