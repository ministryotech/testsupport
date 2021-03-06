﻿// Copyright (c) 2014 Minotech Ltd.
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
    /// Factory interface for different implementations of the helpers.
    /// </summary>
    /// <remarks>To use this you will need to create a Suppert Factory implementation for your chosen unit testing framework.</remarks>
    /// <example>
    ///    public class NUnitSupportFactory : ISupportFactoryWithMocks
    ///    {
    ///        public NUnitSupportFactory()
    ///        {
    ///            AssertionFramework = new NUnitAssertionFramework();
    ///            RouteAssert = new MvcRouteAsserter(AssertionFramework);
    ///            ApiRouteAssert = new WebApiRouteAsserter(AssertionFramework);
    ///        }
    /// 
    ///        public IAssertionFramework AssertionFramework { get; private set; }
    ///        public MvcRouteAsserter RouteAssert { get; private set; }
    ///        public WebApiRouteAsserter ApiRouteAssert { get; private set; }
    ///    }
    /// </example>
    public interface ISupportFactoryWithMocks : ISupportFactory
    {
        /// <summary>
        /// Gets the route asserter.
        /// </summary>
        MvcRouteAsserter RouteAssert { get; }

        /// <summary>
        /// Gets the API route asserter.
        /// </summary>
        WebApiRouteAsserter ApiRouteAssert { get; }
    }
}
