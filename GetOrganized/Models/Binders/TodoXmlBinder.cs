using GetOrganized.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GetOrganized.Models.Binders
{
    public class TodoXmlBinder : IModelBinder
    {

        private readonly IModelBinder _fallbackBinder;

        public TodoXmlBinder(IModelBinder fallbackBinder)
        {
            if (fallbackBinder == null)
                throw new ArgumentNullException(nameof(fallbackBinder));

            _fallbackBinder = fallbackBinder;
        }


        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var todoTitle = bindingContext.HttpContext.Request.Form["Title"].ToString();

            //var rawXml = XmlReader.Create(valueAsString);
            //XDocument doc = XDocument.Load(rawXml);
            //var todoTitle = doc.Root.Element(XName.Get("title")).Value;

            var todo = new Todo();
            todo.Title = todoTitle;
            bindingContext.Result = ModelBindingResult.Success(todo);

            return Task.CompletedTask;
        }
    }
}
