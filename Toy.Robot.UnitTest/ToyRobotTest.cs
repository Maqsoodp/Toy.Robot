using System;
using NUnit;
using NUnit.Framework;
using Toy.Robot.Command;

namespace Toy.Robot.UnitTest
{
    [TestFixture]
    public class ToyRobotTest
    {
        protected IToyRobot _toyRobot;

        [TearDown]
        public void CleaUp()
        {
            this._toyRobot = null;
        }
    }
}
