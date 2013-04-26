using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Wings.Test
{
    [TestFixture]
    class Unitytestdemo
    {
        [TestFixtureSetUp]
        public void RunBeforeAllTests()
        {

            Console.WriteLine("TestFixtureSetUp");

        }

        [SetUp]
        public void RunBeforeEachTest()
        {

            Console.WriteLine("SetUp");

        }
        [Test]
        public void Test1()
        {

            Console.WriteLine("Test1");

        }

        [TearDown]
        public void RunAfterEachTest()
        {

            Console.WriteLine("TearDown");

        }
        [TestFixtureTearDown]
        public void RunAfterAllTests()
        {

            Console.WriteLine("TestFixtureTearDown");

        }


    }
}
