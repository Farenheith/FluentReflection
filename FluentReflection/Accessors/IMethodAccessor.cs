using FluentReflection.Accessors.Base;
using System.Reflection;

namespace FluentReflection.Accessors
{
    public interface IMethodAccessor<TReturnType> : IAccessorBase<MethodInfo, TReturnType>
    {
        TReturnType Do(params object[] parameters);
    }
}
