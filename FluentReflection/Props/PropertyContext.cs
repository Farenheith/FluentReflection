using FluentReflection.Accessors;
using System;
using System.Reflection;

namespace FluentReflection.Props
{
    internal class PropertyContext<TReturnType> : IPropertyAccessor<TReturnType>
    {
        private readonly object _obj;
        private readonly PropertyInfo _accessor;

        public string Name => _accessor.Name;

        public PropertyContext(object obj, PropertyInfo accessor)
        {
            _obj = obj;
            _accessor = accessor;
        }

        public TReturnType Value => (TReturnType)_accessor.GetValue(_obj, null);
    }
}
