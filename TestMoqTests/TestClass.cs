using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMoq;

namespace TestMoqTests
{
    [TestFixture]
    public class TestClass
    {

        public class NewTest
        {
            public int index = 0;
        }

        public IEnumerable TestMethod()
        {
            //return Enum.GetValues(typeof(NewTest));
            return new[] { new TestCaseData(new DateTime(2000, 1, 1)).SetName("test1").Returns(new DateTime(1999,1,1)) };
        }

        [Test]
        public void TestMust_SendWithoutError()
        {
            //arrange
            Mock<ITransport> mockTransport = new Mock<ITransport>();
            FakeTransport testTranspor = new FakeTransport("ok");

            //act
            Messenger msg = new Messenger(testTranspor);
            string result = msg.Send("test");

            //assert
            Assert.IsTrue(result == "ok");
        }
        [Test]
        public void TestMust_GetError()
        {
            FakeTransport testTranspor = new FakeTransport("error");             
            Messenger msg = new Messenger(testTranspor);
            string result = msg.Send("test");
            Assert.IsTrue(result == "error");
        }

        [TestCase("error")]
        [TestCase("ok")]
        public void TestMust_GetResponse(string response)
        {
            FakeTransport testTranspor = new FakeTransport(response);
            Messenger msg = new Messenger(testTranspor);
            string result = msg.Send("test");
            Assert.IsTrue(result == response);
        }

        [Test, TestCaseSource(typeof(TestClass), nameof(TestCases))]
        public DateTime TestMust_CheckTestObject(DateTime testDate)
        {
            FakeTransport testTransport = new FakeTransport("error");
            Messenger msg = new Messenger(testTransport);
            return new DateTime(1999,2,2);
            //string result = msg.Send("test");
            //Assert.IsTrue(result == "error");
        }

        static IEnumerable TestCases()
        {
            yield return new TestCaseData(new DateTime(1999, 2, 2)).Returns(new DateTime(1999, 2, 2));
            yield return new TestCaseData(new DateTime(2000, 2, 2)).Returns(new DateTime(1999, 2, 2));
            yield return new TestCaseData(new DateTime(2000, 1, 2)).Returns(new DateTime(1999, 2, 2));
        }

        static DateTime[] TestDates()
        {
            return new[] { new DateTime(1999, 1, 1), new DateTime(2000, 1, 1) };
        }
    }
}
