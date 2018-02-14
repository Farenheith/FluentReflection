using FluentReflection.Accessors.Base;
using System.Reflection;

namespace FluentReflection.Accessors
{
    public interface IPropertyAccessor<TReturnType> : IAccessorBase<PropertyInfo, TReturnType>
    {
        TReturnType Value { get; }
    }
}
