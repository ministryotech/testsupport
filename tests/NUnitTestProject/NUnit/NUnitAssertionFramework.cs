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
    /// NUnit assertion wrapper for test linked methods.
    /// </summary>
    public class NUnitAssertionFramework : IAssertionFramework
    {
        #region | IsNull |

        /// <summary>
        /// Verifies that the object that is passed in is null
        /// If the object is not null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        public void IsNull<T>(T anObject)
        {
            Assert.IsNull(anObject);
        }

        /// <summary>
        /// Verifies that the object that is passed in is null
        /// If the object is not null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public void IsNull<T>(T anObject, string message)
        {
            Assert.IsNull(anObject, message);
        }

        #endregion

        #region | IsNotNull |

        /// <summary>
        /// Verifies that the object that is passed in is not equal to null
        /// If the object is null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        public void IsNotNull<T>(T anObject)
        {
            Assert.IsNotNull(anObject);
        }

        /// <summary>
        /// Verifies that the object that is passed in is not equal to null
        /// If the object is null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public void IsNotNull<T>(T anObject, string message)
        {
            Assert.IsNotNull(anObject, message);
        }

        #endregion

        #region | IsTrue |

        /// <summary>
        /// Verifies that the object that the conditon passed is true
        /// If the condition does not evaluate to true then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        public void IsTrue(bool condition)
        {
            Assert.IsTrue(condition);
        }

        /// <summary>
        /// Verifies that the object that the conditon passed is true
        /// If the condition does not evaluate to true then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public void IsTrue(bool condition, string message)
        {
            Assert.IsTrue(condition, message);
        }

        /// <summary>
        /// Verifies that the object that the conditon passed is true
        /// If the condition does not evaluate to true then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="args">The args to format the message.</param>
        public void IsTrue(bool condition, string message, params object[] args)
        {
            Assert.IsTrue(condition, message, args);
        }

        #endregion

        #region | IsFalse |

        /// <summary>
        /// Verifies that the object that the conditon passed is false
        /// If the condition does not evaluate to false then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        public void IsFalse(bool condition)
        {
            Assert.IsFalse(condition);
        }

        /// <summary>
        /// Verifies that the object that the conditon passed is false
        /// If the condition does not evaluate to false then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public void IsFalse(bool condition, string message)
        {
            Assert.IsFalse(condition, message);
        }

        /// <summary>
        /// Verifies that the object that the conditon passed is false
        /// If the condition does not evaluate to false then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="args">The args to format the message.</param>
        public void IsFalse(bool condition, string message, params object[] args)
        {
            Assert.IsFalse(condition, message, args);
        }

        #endregion

        #region | AreEqual |

        /// <summary>
        /// Verifies that two objects are equal. Two objects are considered equal if
        /// both are null, or if both have the same value. NUnit has special semantics
        /// for some object types.  If they are not equal an NUnit.Framework.AssertionException
        /// is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        public void AreEqual<T>(T expected, T actual)
        {
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that two objects are equal. Two objects are considered equal if
        /// both are null, or if both have the same value. NUnit has special semantics
        /// for some object types.  If they are not equal an NUnit.Framework.AssertionException
        /// is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public void AreEqual<T>(T expected, T actual, string message)
        {
            Assert.AreEqual(expected, actual, message);
        }

        /// <summary>
        /// Verifies that two strings are equal regardless of casing.
        /// If they are not equal an NUnit.Framework.AssertionException
        /// is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        public void AreCaseInsensitiveEqual<T>(T expected, T actual)
        {
            Assert.True(expected.IsCaseInsensitiveEqualTo(actual), "The values '" + expected + "' and '" + actual + "' differ by more than case.");
        }

        /// <summary>
        /// Verifies that two strings are equal regardless of casing.
        /// If they are not equal an NUnit.Framework.AssertionException
        /// is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public void AreCaseInsensitiveEqual<T>(T expected, T actual, string message)
        {
            Assert.True(expected.IsCaseInsensitiveEqualTo(actual), message + "\nThe values '" + expected + "' and '" + actual + "' differ by more than case.");
        }

        #endregion
    }
}
