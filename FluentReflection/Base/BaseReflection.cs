using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Base
{
    internal static class BaseReflection
    {
        public const BindingFlags PUBLIC = BindingFlags.Public | BindingFlags.Instance;
        public const BindingFlags PUBLIC_STATIC = BindingFlags.Public | BindingFlags.Static;
        public const BindingFlags HIDDEN = BindingFlags.NonPublic | BindingFlags.Instance;
        public const BindingFlags HIDDEN_STATIC = BindingFlags.NonPublic | BindingFlags.Static;
    }
}
