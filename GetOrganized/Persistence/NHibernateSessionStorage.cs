using GetOrganized.Persistence.GetOrganized.Web.Persistence;
using Microsoft.AspNetCore.Http;
using NHibernate;
using System;
using System.Linq;
using ISession = NHibernate.ISession;

namespace GetOrganized.Persistence
{
    public class NHibernateSessionStorage
    {
        private static string CURRENT_SESSION_KEY = "nhibernate.current_session";

        private static HttpContext context;

        public NHibernateSessionStorage(IHttpContextAccessor httpContextAccessor)
        {
            context = httpContextAccessor.HttpContext;
        }

        public ISession RetrieveSession()
        {
            if (!context.Items.ContainsKey(CURRENT_SESSION_KEY))  OpenCurrent();

            var session = context.Items[CURRENT_SESSION_KEY] as ISession;

            if (!session.IsOpen) OpenCurrent();
            return session;
        }

        private void OpenCurrent()
        {
            ISession session = NHibernateConfiguration.CreateAndOpenSession();
            context.Items[CURRENT_SESSION_KEY] = session;
        }

        public void DisposeCurrent()
        {
            if (!context.Items.ContainsKey(CURRENT_SESSION_KEY))
                return;
            ISession session = RetrieveSession();
            if (session != null && session.IsOpen)
                session.Close();
            context.Items.Remove(CURRENT_SESSION_KEY);
        }
    }
}
