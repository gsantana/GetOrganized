using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Persistence
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        public ISession session { get; set; }
        public TransactionAttribute(ISession session)
        {
            this.session = session;
        }

        public override void OnActionExecuting(
    ActionExecutingContext filterContext)
        {
            //var session = (ISession)filterContext.HttpContext.RequestServices.GetService(typeof(ISession));
            session.Transaction.Begin();
        }

        public override void OnActionExecuted(
          ActionExecutedContext filterContext)
        {
            //var session = (ISession)filterContext.HttpContext.RequestServices.GetService(typeof(ISession));
            var currentTransaction = session.Transaction;

            if (currentTransaction.IsActive)
            {
                if (filterContext.Exception == null)
                {
                    currentTransaction.Commit();
                }
                else
                {
                    currentTransaction.Rollback();
                }
            }
        }
    }
}
