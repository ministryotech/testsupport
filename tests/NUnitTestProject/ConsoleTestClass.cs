using Ministry.TestSupport.NUnit;
using NUnit.Framework;

namespace NUnitTestProject
{
    /// <summary>
    /// Empty Test Class to test inheritance.
    /// </summary>
    [TestFixture]
    public class ConsoleTestClass : NUnitConsoleTestBase
    {
        [Test]
        public void TestTrue()
        {
            AssertApplicationRunsSuccessfully();
            Assert.IsTrue(true);
        }

        [Test]
        public void TestPrintsHello()
        {
            AssertApplicationRunsSuccessfully();
            AssertConsoleOutputContains("Hello");
            AssertConsoleOutputDoesNotContain("Goodbye");
        }

        protected override string AppFileName
        {
            get { return @"C:\Development\Projects\Ministry OSS\testsupport\tests\printhello.bat"; }
        }
    }
}
