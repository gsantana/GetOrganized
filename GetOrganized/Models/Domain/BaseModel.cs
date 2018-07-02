using AutoProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GetOrganized.Models.Domain
{
    public class BaseModel
    {
        [GetInterceptor]
        protected T GetValue<T>(string name, PropertyInfo propertyInfo, object fieldValue, ref T refToBackingField)
        {
            var a = name;
             //refToBackingField = default(T);

            if (fieldValue == null)
            {
                refToBackingField = default(T);
            }
            return (T)fieldValue;
        }

        [SetInterceptor]
        protected void SetValue<T>(string name, PropertyInfo propertyInfo, T genricNewValue, out T refToBackingField)
        {
            refToBackingField = genricNewValue;
        }

    }
}
