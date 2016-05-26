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

using Ministry.TestSupport;
using NUnit.Framework;

namespace NUnitTestProject
{
    /// <summary>
    /// A base class to provide elements for interracting with a Console Application.
    /// </summary>
    [TestFixture]
    public abstract class NUnitConsoleTestBase : ConsoleTestBase
    {
        #region | SetUp & TearDown |

        /// <summary>
        /// Sets up the test fixture to capture the output of the console app.
        /// </summary>
        [OneTimeSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
        }

        /// <summary>
        /// Returns the output stream to normal.
        /// </summary>
        [OneTimeTearDown]
        public override void FixtureTearDown()
        {
            base.FixtureTearDown();
        }

        /// <summary>
        /// Clears the replaced output stream text dump before each test.
        /// </summary>
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        /// <summary>
        /// Writes the output to the text dump at the end of each test.
        /// </summary>
        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }

        #endregion

        #region | Properties |

        /// <summary>
        /// Gets the test support factory.
        /// </summary>
        protected override ISupportFactory TestSupportFactory
        {
            get { return new NUnitSupportFactory(); }
        }

        #endregion
    }
}
