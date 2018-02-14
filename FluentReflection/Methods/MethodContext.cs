using System;
using System.Reflection;
using FluentReflection.Accessors;
using FluentReflection.Methods.Base;

namespace FluentReflection.Methods
{
    internal class MethodContext<TReturnType> : MethodContextBase<TReturnType>, IMethodAccessor<TReturnType>
    {
        public MethodContext(object obj, MethodInfo accessor) : base(obj, accessor)
        {
            if (accessor.IsStatic || accessor.IsGenericMethodDefinition)
                throw new InvalidOperationException("Informed method must be an instance non generic method");
        }
    }
}
