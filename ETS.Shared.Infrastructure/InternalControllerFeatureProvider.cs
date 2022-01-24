using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Reflection;

namespace ETS.Shared.Infrastructure
{
    internal class InternalControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            return typeInfo.IsClass
                    && (!typeInfo.IsAbstract
                    && (!typeInfo.ContainsGenericParameters
                    && (!typeInfo.IsDefined(typeof(NonControllerAttribute))
                    && (typeInfo.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) 
                    || typeInfo.IsDefined(typeof(ControllerAttribute))))));
        }
    }
}
