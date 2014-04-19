// Copyright (c) 2012 Minotech Ltd.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files
// (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do 
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ministry.TestSupport.MSTest
{
    /// <summary>
    /// A base class to provide elements for interracting with a Console Application.
    /// </summary>
    [TestClass]
    public abstract class MSTestConsoleTestBase : ConsoleTestBase
    {
        #region | SetUp & TearDown |

        /// <summary>
        /// Sets up the test fixture to capture the output of the console app and Clears the replaced output stream text dump before each test.
        /// </summary>
        [TestInitialize]
        public override void SetUp()
        {
            base.FixtureSetUp();
            base.SetUp();
        }

        /// <summary>
        /// Writes the output to the text dump at the end of each test and Returns the output stream to normal.
        /// </summary>
        [TestCleanup]
        public override void TearDown()
        {
            base.TearDown();
            base.FixtureTearDown();
        }

        #endregion

        #region | Properties |

        /// <summary>
        /// Getsthe test support factory.
        /// </summary>
        /// <value>
        /// The test support factory.
        /// </value>
        protected override ISupportFactory TestSupportFactory
        {
            get { return new MSTestSupportFactory(); }
        }

        #endregion
    }
}
