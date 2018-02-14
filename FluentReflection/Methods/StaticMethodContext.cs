using FluentReflection.Accessors;
using FluentReflection.Methods.Base;
using System;
using System.Reflection;

namespace FluentReflection.Methods
{
    internal class StaticMethodContext<TReturnType> : MethodContextBase<TReturnType>, IMethodAccessor<TReturnType>
    {
        public StaticMethodContext(MethodInfo accessor) : base(null, accessor)
        {
            if (!accessor.IsStatic || accessor.IsGenericMethodDefinition)
                throw new InvalidOperationException("Informed method must be a static non generic method");
        }
    }
}