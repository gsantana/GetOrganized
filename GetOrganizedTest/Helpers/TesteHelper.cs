using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GetOrganizedTest.Helpers
{
    public class TesteHelper
    {
        public static bool AssertIsAuthorized(ICustomAttributeProvider type)
        {
            return type.GetCustomAttributes(false).Any(x => x.GetType() == typeof(AuthorizeAttribute));
        }
        public static bool AssertIsAuthorized(Type type, string action, params Type[] parameters)
        {
            var method = type.GetMethod(action, parameters);
            return AssertIsAuthorized(method);
        }
    }
}
