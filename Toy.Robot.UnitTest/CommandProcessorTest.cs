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
            Assert.AreEqual(report.Face, expectedFace.ToUpper());
        }


        [TestCase(5, -5, "column", -5)]
        [TestCase(-5, -5, "row", -5)]
        [TestCase(-5, 5, "row", -5)]
        public void TestCommandProcessor_WithNegativeSize(int tableSizeX, int tableSizeY, string errorSide, int errorValue)
        {
            // Act
            var ex = Assert.Throws
                   <Exception>(
                       () => new CommandProcessor(tableSizeX, tableSizeY)
                   );

            // Assert

            Assert.That(ex, Is.Not.Null);
            Assert.AreEqual(ex.Message, $"Table {errorSide} value should be positive {errorValue}");

        }

        [TestCase(5, 5, "place 1 2 nrth", "Provide valid face: North,East,West,South")]
        [TestCase(5, 5, "place a,b nrth", "Invalid place command: Use E.g. place 0 0 East")]
        [TestCase(5, 5, "place a b north", "provide valid numeric value")]
        [TestCase(5, 5, "place 6 6 north", "Toy robot should be placed with in the table 5 5")]
        [TestCase(5, 5, "place -2 -6 north", "Toy robot should be placed with in the table 5 5")]
        [TestCase(5, 5, "plce 2 2 north", "Not a valid command")]
        public void TestCommandProcessor_validatePlaceCommands(int tableSizeX, int tableSizeY, string command, string expectdMsg)
        {
            // Act
            var ex = Assert.Throws
                   <Exception>(
                       () => new CommandProcessor(tableSizeX, tableSizeY).Run(command.Trim().Split(' '))
                   );

            // Assert

            Assert.That(ex, Is.Not.Null);
            Assert.AreEqual(ex.Message, expectdMsg);

        }
    }
}
