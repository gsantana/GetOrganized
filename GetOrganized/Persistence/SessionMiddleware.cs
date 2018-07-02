using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence
{
    public class SessionMiddleware
    {

        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, NHibernate.ISession session)
        {
            await _next(httpContext);

            if (session != null && session.IsOpen)
                session.Close();

        }
    }
}
