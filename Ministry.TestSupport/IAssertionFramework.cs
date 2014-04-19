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

namespace Ministry.TestSupport
{
    /// <summary>
    /// An Interface to wrap common assertion tasks of different unit testing frameworks.
    /// </summary>
    public interface IAssertionFramework
    {
        #region | IsNull |

        /// <summary>
        /// Verifies that the object that is passed in is null
        /// If the object is not null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        void IsNull<T>(T anObject);

        /// <summary>
        /// Verifies that the object that is passed in is null
        /// If the object is not null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        void IsNull<T>(T anObject, string message);

        #endregion

        #region | IsNotNull |

        /// <summary>
        /// Verifies that the object that is passed in is not equal to null
        /// If the object is null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        void IsNotNull<T>(T anObject);

        /// <summary>
        /// Verifies that the object that is passed in is not equal to null
        /// If the object is null then an AssertionException is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="anObject">An object to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        void IsNotNull<T>(T anObject, string message);

        #endregion

        #region | IsTrue |

        /// <summary>
        /// Verifies that the object that the conditon passed is true
        /// If the condition does not evaluate to true then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        void IsTrue(bool condition);

        /// <summary>
        /// Verifies that the object that the conditon passed is true
        /// If the condition does not evaluate to true then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        void IsTrue(bool condition, string message);

        /// <summary>
        /// Verifies that the object that the conditon passed is true
        /// If the condition does not evaluate to true then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="args">The args to format the message.</param>
        void IsTrue(bool condition, string message, params object[] args);

        #endregion

        #region | IsFalse |

        /// <summary>
        /// Verifies that the object that the conditon passed is false
        /// If the condition does not evaluate to false then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        void IsFalse(bool condition);

        /// <summary>
        /// Verifies that the object that the conditon passed is false
        /// If the condition does not evaluate to false then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        void IsFalse(bool condition, string message);

        /// <summary>
        /// Verifies that the object that the conditon passed is false
        /// If the condition does not evaluate to false then an AssertionException is thrown.
        /// </summary>
        /// <param name="condition">A condition to test.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="args">The args to format the message.</param>
        void IsFalse(bool condition, string message, params object[] args);

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
        void AreEqual<T>(T expected, T actual);

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
        void AreEqual<T>(T expected, T actual, string message);

        /// <summary>
        /// Verifies that two strings are equal regardless of casing.
        /// If they are not equal an NUnit.Framework.AssertionException
        /// is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        void AreCaseInsensitiveEqual<T>(T expected, T actual);

        /// <summary>
        /// Verifies that two strings are equal regardless of casing.
        /// If they are not equal an NUnit.Framework.AssertionException
        /// is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the object to test.</typeparam>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        void AreCaseInsensitiveEqual<T>(T expected, T actual, string message);

        #endregion
    }
}
