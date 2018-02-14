using FluentReflection.Accessors.Base;
using System;
using System.Reflection;

namespace FluentReflection.Accessors
{
    public interface IGenericMethodAccessor<TReturnType> : IAccessorBase<MethodInfo, TReturnType>
    {
        IMethodAccessor<TReturnType> Gen(Type[] types);

        IMethodAccessor<TReturnType> Gen<T1>();

        IMethodAccessor<TReturnType> Gen<T1, T2>();

        IMethodAccessor<TReturnType> Gen<T1, T2, T3>();

        IMethodAccessor<TReturnType> Gen<T1, T2, T3, T4>();

        IMethodAccessor<TReturnType> Gen<T1, T2, T3, T4, T5>();
    }
}
