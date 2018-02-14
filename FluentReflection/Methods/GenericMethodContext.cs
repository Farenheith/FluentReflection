using FluentReflection.Accessors;
using FluentReflection.Methods.Base;
using System;
using System.Reflection;

namespace FluentReflection.Methods
{
    internal class GenericMethodContext<TReturnType> : MethodContextBase<TReturnType>, IGenericMethodAccessor<TReturnType>
    {
        public GenericMethodContext(object obj, MethodInfo accessor) : base(obj, accessor)
        {
            if (accessor.IsStatic || !accessor.IsGenericMethodDefinition)
                throw new InvalidOperationException("Informed method must be an instance generic method definition");
        }

        internal MethodInfo GenInternal(Type[] types) => _accessor.MakeGenericMethod(types);

        public IMethodAccessor<TReturnType> Gen(Type[] types)
            => new MethodContext<TReturnType>(_obj, _accessor);

        public IMethodAccessor<TReturnType> Gen<T1>() => Gen(new[] { typeof(T1) });

        public IMethodAccessor<TReturnType> Gen<T1, T2>()
             => Gen(new[] { typeof(T1), typeof(T2) });

        public IMethodAccessor<TReturnType> Gen<T1, T2, T3>()
            => Gen(new[] { typeof(T1), typeof(T2), typeof(T3) });

        public IMethodAccessor<TReturnType> Gen<T1, T2, T3, T4>()
            => Gen(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });

        public IMethodAccessor<TReturnType> Gen<T1, T2, T3, T4, T5>()
            => Gen(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
    }
}