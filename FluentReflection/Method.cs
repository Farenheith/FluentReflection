using FluentReflection.Accessors;
using FluentReflection.Base;
using FluentReflection.Methods;
using System;
using System.Reflection;

namespace FluentReflection
{
    public static class Method
    {
        internal static IMethodAccessor<TReturnType> InternalFunc<TReturnType>(object obj, string methodName, BindingFlags bindingFlags, params Type[] types)
        {
            var method = obj.GetType().GetMethod(methodName, bindingFlags, null, types, null);
            if (method.IsStatic) return new StaticMethodContext<TReturnType>(method);
            else return new MethodContext<TReturnType>(obj, method);
        }

        internal static IGenericMethodAccessor<TReturnType> InternalGenFunc<TReturnType>(object obj, string methodName, BindingFlags bindingFlags, params Type[] types)
        {
            var method = obj.GetType().GetMethod(methodName, bindingFlags, null, types, null);
            if (method.IsStatic) return new GenericStaticMethodContext<TReturnType>(method);
            else return new GenericMethodContext<TReturnType>(obj, method);
        }

        #region Public Generic Method Accessors
        public static IGenericMethodAccessor<TReturnType> GenFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalGenFunc<TReturnType>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IGenericMethodAccessor<object> GenAction(object obj, string methodName, params Type[] types)
            => InternalGenFunc<object>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IGenericMethodAccessor<dynamic> GenDyn(object obj, string methodName, params Type[] types)
            => InternalGenFunc<dynamic>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IGenericMethodAccessor<TReturnType> StaticGenFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalGenFunc<TReturnType>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);

        public static IGenericMethodAccessor<object> StaticGenAction(object obj, string methodName, params Type[] types)
            => InternalGenFunc<object>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);

        public static IGenericMethodAccessor<dynamic> StaticGenDyn(object obj, string methodName, params Type[] types)
            => InternalGenFunc<dynamic>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);
        #endregion

        #region Hidden Generic Method Accessors
        public static IGenericMethodAccessor<TReturnType> HiddenGenFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalGenFunc<TReturnType>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IGenericMethodAccessor<object> HiddenGenAction(object obj, string methodName, params Type[] types)
            => InternalGenFunc<object>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IGenericMethodAccessor<dynamic> HiddenGenDyn(object obj, string methodName, params Type[] types)
            => InternalGenFunc<dynamic>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IGenericMethodAccessor<TReturnType> StaticHiddenGenFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalGenFunc<TReturnType>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);

        public static IGenericMethodAccessor<object> StaticHiddenGenAction(object obj, string methodName, params Type[] types)
            => InternalGenFunc<object>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);

        public static IGenericMethodAccessor<dynamic> StaticHiddenGenDyn(object obj, string methodName, params Type[] types)
            => InternalGenFunc<dynamic>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);
        #endregion

        #region Public Method Accessors
        public static IMethodAccessor<TReturnType> Func<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalFunc<TReturnType>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IMethodAccessor<object> Action(object obj, string methodName, params Type[] types)
            => InternalFunc<object>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IMethodAccessor<dynamic> Dyn(object obj, string methodName, params Type[] types)
            => InternalFunc<dynamic>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IMethodAccessor<TReturnType> StaticFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalFunc<TReturnType>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);

        public static IMethodAccessor<object> StaticAction(object obj, string methodName, params Type[] types)
            => InternalFunc<object>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);

        public static IMethodAccessor<dynamic> StaticDyn(object obj, string methodName, params Type[] types)
            => InternalFunc<dynamic>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);
        #endregion

        #region Hidden Method Accessors
        public static IMethodAccessor<TReturnType> HiddenFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalFunc<TReturnType>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IMethodAccessor<object> HiddenAction(object obj, string methodName, params Type[] types)
            => InternalFunc<object>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IMethodAccessor<dynamic> HiddeDyn(object obj, string methodName, params Type[] types)
            => InternalFunc<dynamic>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IMethodAccessor<TReturnType> HiddenStaticFunc<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalFunc<TReturnType>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);

        public static IMethodAccessor<object> HiddenStaticAction(object obj, string methodName, params Type[] types)
            => InternalFunc<object>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);

        public static IMethodAccessor<dynamic> HiddenStaticDyn(object obj, string methodName, params Type[] types)
            => InternalFunc<dynamic>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);
        #endregion
    }
}
