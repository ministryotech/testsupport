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

using System.Web;
using Moq;

namespace Ministry.TestSupport
{
    public static class ContextBuilder
    {
        /// <summary>
        /// Gets a simple mock context.
        /// </summary>
        /// <returns></returns>
        public static Mock<HttpContextBase> GetMockContext()
        {
            return GetMockContext(GetMockRequestContext(), GetMockResponseContext());
        }

        /// <summary>
        /// Gets a simple mock context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static Mock<HttpContextBase> GetMockContext(Mock<HttpRequestBase> request)
        {
            return GetMockContext(request, GetMockResponseContext());
        }

        /// <summary>
        /// Gets a simple mock context.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static Mock<HttpContextBase> GetMockContext(Mock<HttpResponseBase> response)
        {
            return GetMockContext(GetMockRequestContext(), response);
        }

        /// <summary>
        /// Gets a simple mock context.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        public static Mock<HttpContextBase> GetMockContext(Mock<HttpRequestBase> request, Mock<HttpResponseBase> response)
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Request).Returns(request.Object);
            mockHttpContext.Setup(c => c.Response).Returns(response.Object);
            return mockHttpContext;
        }

        /// <summary>
        /// Gets the mock request context.
        /// </summary>
        public static Mock<HttpRequestBase> GetMockRequestContext()
        {
            var request = new Mock<HttpRequestBase>();
            request.Setup(r => r.HttpMethod).Returns("GET");
            return request;
        }

        /// <summary>
        /// Gets the mock response context.
        /// </summary>
        public static Mock<HttpResponseBase> GetMockResponseContext()
        {
            return new Mock<HttpResponseBase>();
        }
    }
}
