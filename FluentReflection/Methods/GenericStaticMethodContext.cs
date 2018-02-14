using FluentReflection.Accessors;
using FluentReflection.Methods.Base;
using System;
using System.Reflection;

namespace FluentReflection.Methods
{
    internal class GenericStaticMethodContext<TReturnType> : GenericMethodContext<TReturnType>
    {
        public GenericStaticMethodContext(MethodInfo accessor)
            : base(null, accessor)
        {
            if (!accessor.IsStatic || !accessor.IsGenericMethodDefinition)
                throw new InvalidOperationException("Informed method must be an instance generic method definition");
        }
    }
}