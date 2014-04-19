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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Http;

namespace Ministry.TestSupport
{
    /// <summary>
    /// Tools for testing attributes.
    /// </summary>
    public static class AttributeInterrogator
    {
        /// <summary>
        /// Determines if a method is decorated by the specified attribute type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="expression">The method.</param>
        /// <returns>[true] if the attribute is applied.</returns>
        public static bool MethodHasAttribute<TAttribute>(Expression<Action> expression)
            where TAttribute : Attribute
        {
            MemberInfo member = MethodOf(expression);
            var appliedToMethod = MemberHasAttribute<TAttribute>(member);

            return (appliedToMethod || TypeHasAttribute<TAttribute>(member.DeclaringType));
        }

        /// <summary>
        /// Determines if a type is decorated by the specified attribute type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="t">The type.</param>
        /// <returns>[true] if the attribute is applied.</returns>
        public static bool TypeHasAttribute<TAttribute>(Type t)
            where TAttribute : Attribute
        {
            return MemberHasAttribute<TAttribute>(t);
        }

        /// <summary>
        /// Determines if a method is decorated by the authorize attribute type.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="role">The role to authorize.</param>
        /// <returns></returns>
        public static bool MethodHasAuthorizeAttribute(Expression<Action> expression, string role = "")
        {
            var attributeExists = MethodHasAttribute<AuthorizeAttribute>(expression);
            if (!attributeExists) return false;
            return String.IsNullOrEmpty(role) || AuthorizationAppliesToRole(MethodOf(expression), role);
        }

        /// <summary>
        /// Determines if a type is decorated by the authorize attribute type.
        /// </summary>
        /// <param name="t">The type.</param>
        /// <param name="role">The role to authorize.</param>
        /// <returns></returns>
        public static bool TypeHasAuthorizeAttribute(Type t, string role = "")
        {
            var attributeExists = TypeHasAttribute<AuthorizeAttribute>(t);
            if (!attributeExists) return false;
            return String.IsNullOrEmpty(role) || AuthorizationAppliesToRole(t, role);
        }

        #region | Private Methods |

        /// <summary>
        /// Determines if a type is authorized for a specific role.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        private static bool AuthorizationAppliesToRole(MemberInfo info, string role)
        {
            var attrs = info.GetCustomAttributes<AuthorizeAttribute>(true);

            return attrs.Any(attr => attr.Roles.Contains(role));
        }

        /// <summary>
        /// Determines if a member is decorated by the specified attribute type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns>[true] if the attribute is applied.</returns>
        private static bool MemberHasAttribute<TAttribute>(MemberInfo member)
            where TAttribute : Attribute
        {
            const bool includeInherited = true;
            return member.GetCustomAttributes(typeof(TAttribute), includeInherited).Any();
        }

        /// <summary>
        /// Gets the method of an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        private static MethodInfo MethodOf(Expression<Action> expression)
        {
            var body = (MethodCallExpression)expression.Body;
            return body.Method;
        }

        #endregion
    }
}
