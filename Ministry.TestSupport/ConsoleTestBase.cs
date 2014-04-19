// Copyright (c) 2014 Minotech Ltd.
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

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Ministry.TestSupport
{
    /// <summary>
    /// A base class to provide elements for interracting with a Console Application.
    /// </summary>
    public abstract class ConsoleTestBase
    {
        #region | Properties |

        /// <summary>
        /// Gets or sets the standard output.
        /// </summary>
        protected TextWriter StandardOutput { get; set; }

        /// <summary>
        /// Gets or sets the test console.
        /// </summary>
        protected StringWriter TestConsole { get; set; }

        /// <summary>
        /// Gets or sets the test string builder.
        /// </summary>
        protected StringBuilder TestStringBuilder { get; set; }

        /// <summary>
        /// Gets the name of the executable to test.
        /// </summary>
        protected abstract string AppFileName { get; }

        /// <summary>
        /// Gets or sets the test support factory.
        /// </summary>
        protected abstract ISupportFactory TestSupportFactory { get; }

        #endregion

        #region | SetUp & TearDown |

        /// <summary>
        /// Sets up the test fixture to capture the output of the console app.
        /// </summary>
        public virtual void FixtureSetUp()
        {
            string assemblyCodeBase = Assembly.GetExecutingAssembly().CodeBase;
            string dirName = Path.GetDirectoryName(assemblyCodeBase);
            if (dirName.StartsWith("file:\\")) dirName = dirName.Substring(6);
            Environment.CurrentDirectory = dirName;

            TestStringBuilder = new StringBuilder();
            TestConsole = new StringWriter(TestStringBuilder);
            StandardOutput = System.Console.Out;
            System.Console.SetOut(TestConsole);
        }

        /// <summary>
        /// Returns the output stream to normal.
        /// </summary>
        public virtual void FixtureTearDown()
        {
            System.Console.SetOut(StandardOutput);
        }

        /// <summary>
        /// Clears the replaced output stream text dump before each test.
        /// </summary>
        public virtual void SetUp()
        {
            TestStringBuilder.Remove(0, TestStringBuilder.Length);
        }

        /// <summary>
        /// Writes the output to the text dump at the end of each test.
        /// </summary>
        public virtual void TearDown()
        {
            StandardOutput.Write(TestStringBuilder.ToString());
        }

        #endregion

        #region | Assertions |

        /// <summary>
        /// Runs up the application and asserts that it runs succesfully.
        /// </summary>
        /// <param name="arguments">The arguments for console application if required.</param>
        protected void AssertApplicationRunsSuccessfully(string arguments = "")
        {
            AssertApplicationReturnsExitCode(0, arguments);
        }

        /// <summary>
        /// Runs up the application and asserts that the exit code matches the value provided.
        /// </summary>
        /// <param name="arguments">The arguments for console application if required.</param>
        /// <param name="exitCode">The exit code to look for.</param>
        protected void AssertApplicationReturnsExitCode(int exitCode, string arguments = "")
        {
            TestSupportFactory.AssertionFramework.AreEqual(exitCode, StartConsoleApplication(), "The application exist code was not as expected.");
        }

        /// <summary>
        /// Asserts that the console output contains a specified string.
        /// </summary>
        /// <param name="desiredContent">The string to look for.</param>
        protected void AssertConsoleOutputContains(string desiredContent)
        {
            TestSupportFactory.AssertionFramework.IsTrue(TestStringBuilder.ToString().Contains(desiredContent), "The output was " + TestStringBuilder.ToString());
        }

        /// <summary>
        /// Asserts that the console output does not contain a specified string.
        /// </summary>
        /// <param name="undesirableContent">The string to look for.</param>
        protected void AssertConsoleOutputDoesNotContain(string undesirableContent)
        {
            TestSupportFactory.AssertionFramework.IsFalse(TestStringBuilder.ToString().Contains(undesirableContent), "The output was " + TestStringBuilder.ToString());
        }

        #endregion

        #region | Protected Methods |

        /// <summary>
        /// Starts the console application.
        /// </summary>
        /// <param name="arguments">The arguments for console application if required.</param>
        /// <returns>exit code</returns>
        protected int StartConsoleApplication(string arguments = "")
        {
            Process consoleExectionProcess = new Process();
            consoleExectionProcess.StartInfo.FileName = AppFileName;
            consoleExectionProcess.StartInfo.Arguments = arguments;
            consoleExectionProcess.StartInfo.UseShellExecute = false;
            consoleExectionProcess.StartInfo.RedirectStandardOutput = true;
            consoleExectionProcess.StartInfo.RedirectStandardError = true;
            consoleExectionProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

            consoleExectionProcess.Start();
            consoleExectionProcess.WaitForExit();

            System.Console.WriteLine(consoleExectionProcess.StandardOutput.ReadToEnd());
            System.Console.Write(consoleExectionProcess.StandardError.ReadToEnd());

            return consoleExectionProcess.ExitCode;
        }

        #endregion
    }
}
