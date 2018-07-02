using GetOrganized.Models.Vadation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NHibernate.Validator.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOrganized.Extensions
{
    public static class ValidationExtension
    {
        public static void Validate(this IValidatable model,
        ModelStateDictionary state)
        {
            InvalidValue[] invalidValues =
            new ValidatorEngine().Validate(model);
            foreach (var error in invalidValues)
            {
                var errorMessage = error.PropertyName + " " + error.Message;
                state.AddModelError(errorMessage, errorMessage);
            }
        }
    }
}
