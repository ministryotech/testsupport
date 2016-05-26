using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestTestProject
{
    /// <summary>
    /// Empty Test Class to test inheritance.
    /// </summary>
    [TestClass]
    public class ConsoleTestClass : MSTestConsoleTestBase
    {
        [TestMethod]
        public void TestTrue()
        {
            AssertApplicationRunsSuccessfully();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestPrintsHello()
        {
            AssertApplicationRunsSuccessfully();
            AssertConsoleOutputContains("Hello");
            AssertConsoleOutputDoesNotContain("Goodbye");
        }

        protected override string AppFileName
        {
            get { return @"C:\Development\OSS\testsupport\tests\printhello.bat"; }
        }
    }
}
