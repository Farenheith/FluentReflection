using System;
using System.Reflection;

namespace FluentReflection.Methods.Base
{
    internal class MethodContextBase<TReturnType>
    {
        protected readonly object _obj;
        protected readonly MethodInfo _accessor;

        public string Name => _accessor.Name;

        public MethodContextBase(object obj, MethodInfo accessor)
        {
            _obj = obj;
            _accessor = accessor;
        }

        public TReturnType Do(params object[] parameters) => (TReturnType)_accessor.Invoke(_obj, parameters);

        MethodInfo GenInternal(Type[] types) => _accessor.MakeGenericMethod(types);
    }
}