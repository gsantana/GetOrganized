using GetOrganized.Models.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Models.Binders
{
    public class TodoModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.IsComplexType && context.Metadata.ModelType == typeof(Todo)) // only encode string types
            {
                return new TodoXmlBinder(new SimpleTypeModelBinder(context.Metadata.ModelType));
            }

            return null;
        }
    }
}
