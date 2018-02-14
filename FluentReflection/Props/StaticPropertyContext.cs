using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Props
{
    internal class StaticPropertyContext<TReturnType> : PropertyContext<TReturnType>
    {
        public StaticPropertyContext(PropertyInfo accessor) : base(null, accessor) { }
    }
}
