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

namespace Ministry.TestSupport.NUnit
{
    /// <summary>
    /// Factory class for providing NUnit implementations of the helpers.
    /// </summary>
    public class NUnitSupportFactoryWithMocks : NUnitSupportFactory, ISupportFactoryWithMocks
    {
        /// <summary>
        /// Initializes the <see cref="NUnitSupportFactoryWithMocks"/> class.
        /// </summary>
        public NUnitSupportFactoryWithMocks()
            : base()
        {
            RouteAssert = new MvcRouteAsserter(AssertionFramework);
            ApiRouteAssert = new WebApiRouteAsserter(AssertionFramework);
        }

        /// <summary>
        /// Gets the route asserter.
        /// </summary>
        public MvcRouteAsserter RouteAssert { get; private set; }

        /// <summary>
        /// Gets the API route asserter.
        /// </summary>
        public WebApiRouteAsserter ApiRouteAssert { get; private set; }
    }
}
