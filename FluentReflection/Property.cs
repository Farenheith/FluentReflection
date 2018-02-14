using FluentReflection.Accessors;
using System;
using System.Reflection;
using FluentReflection.Base;
using FluentReflection.Props;
using System.Collections.Generic;
using System.Linq;

namespace FluentReflection
{
    public static class Property
    {
        #region Property acessor internal
        internal static IPropertyAccessor<TReturnType> InternalStaticGet<TReturnType>(object obj, string name, BindingFlags bindingFlags, params Type[] types)
        {
            var property = obj.GetType().GetProperty(name, bindingFlags, null, typeof(TReturnType), types, null);
            return new StaticPropertyContext<TReturnType>(property);
        }

        internal static IPropertyAccessor<TReturnType> InternalGet<TReturnType>(object obj, string name, BindingFlags bindingFlags, params Type[] types)
        {
            var property = obj.GetType().GetProperty(name, bindingFlags, null, typeof(TReturnType), types, null);
            return new PropertyContext<TReturnType>(obj, property);
        }

        internal static IPropertyAccessor<TReturnType> InternalStaticGetDyn<TReturnType>(object obj, string name, BindingFlags bindingFlags, params Type[] types)
        {
            var property = obj.GetType().GetProperty(name, bindingFlags);
            return new StaticPropertyContext<TReturnType>(property);
        }

        internal static IPropertyAccessor<TReturnType> InternalGetDyn<TReturnType>(object obj, string name, BindingFlags bindingFlags, params Type[] types)
        {
            var property = obj.GetType().GetProperty(name, bindingFlags);
            return new PropertyContext<TReturnType>(obj, property);
        }
        #endregion

        #region Public Property Accessors
        public static IPropertyAccessor<TReturnType> Get<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalGet<TReturnType>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IPropertyAccessor<dynamic> Dyn(object obj, string methodName, params Type[] types)
            => InternalGetDyn<dynamic>(obj, methodName, BaseReflection.PUBLIC, types);

        public static IPropertyAccessor<TReturnType> StaticGet<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalStaticGet<TReturnType>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);

        public static IPropertyAccessor<dynamic> StaticDyn(object obj, string methodName, params Type[] types)
            => InternalStaticGetDyn<dynamic>(obj, methodName, BaseReflection.PUBLIC_STATIC, types);
        #endregion

        #region Hidden Property Accessors
        public static IPropertyAccessor<TReturnType> HiddenGet<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalGet<TReturnType>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IPropertyAccessor<dynamic> HiddeDyn(object obj, string methodName, params Type[] types)
            => InternalGetDyn<dynamic>(obj, methodName, BaseReflection.HIDDEN, types);

        public static IPropertyAccessor<TReturnType> HiddenStaticGet<TReturnType>(object obj, string methodName, params Type[] types)
            => InternalStaticGet<TReturnType>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);

        public static IPropertyAccessor<dynamic> HiddenStaticDyn(object obj, string methodName, params Type[] types)
            => InternalStaticGetDyn<dynamic>(obj, methodName, BaseReflection.HIDDEN_STATIC, types);
        #endregion

        #region Properties Accessors Internal
        internal static IEnumerable<IPropertyAccessor<object>> InternalProperties<TReturnType>(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
        {
            foreach (var property in obj.GetType().GetProperties(flags).Where(x => condition(x) && typeof(TReturnType).IsAssignableFrom(x.PropertyType)))
            {
                yield return new PropertyContext<object>(obj, property);
            }
        }

        internal static IEnumerable<IPropertyAccessor<object>> InternalProperties(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
        {
            foreach (var property in obj.GetType().GetProperties(flags).Where(condition))
            {
                yield return new PropertyContext<object>(obj, property);
            }
        }

        internal static IEnumerable<IPropertyAccessor<dynamic>> InternalPropertiesDyn(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
        {
            foreach (var property in obj.GetType().GetProperties(flags).Where(condition))
            {
                yield return new PropertyContext<dynamic>(obj, property);
            }
        }
        #endregion

        #region Public Properties Accessors
        public static IEnumerable<IPropertyAccessor<object>> Props<TReturnType>(object obj, Func<PropertyInfo, bool> condition)
            => InternalProperties<TReturnType>(obj, BaseReflection.PUBLIC, condition);

        public static IEnumerable<IPropertyAccessor<object>> Props(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalProperties(obj, BaseReflection.PUBLIC, condition);

        public static IEnumerable<IPropertyAccessor<dynamic>> PropsDyn(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalPropertiesDyn(obj, BaseReflection.PUBLIC, condition);
        #endregion

        #region Public Static Properties Accessors
        public static IEnumerable<IPropertyAccessor<object>> StaticProps<TReturnType>(object obj, Func<PropertyInfo, bool> condition)
            => InternalProperties<TReturnType>(obj, BaseReflection.PUBLIC_STATIC, condition);

        public static IEnumerable<IPropertyAccessor<object>> StaticProps(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalProperties(obj, BaseReflection.PUBLIC_STATIC, condition);

        public static IEnumerable<IPropertyAccessor<dynamic>> StaticPropsDyn(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalPropertiesDyn(obj, BaseReflection.PUBLIC_STATIC, condition);
        #endregion

        #region Public Properties Accessors
        public static IEnumerable<IPropertyAccessor<object>> HiddenProps<TReturnType>(object obj, Func<PropertyInfo, bool> condition)
            => InternalProperties<TReturnType>(obj, BaseReflection.HIDDEN, condition);

        public static IEnumerable<IPropertyAccessor<object>> HiddenProps(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalProperties(obj, BaseReflection.HIDDEN, condition);

        public static IEnumerable<IPropertyAccessor<dynamic>> HiddenPropsDyn(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalPropertiesDyn(obj, BaseReflection.HIDDEN, condition);
        #endregion

        #region Public Static Properties Accessors
        public static IEnumerable<IPropertyAccessor<object>> HiddenStaticProps<TReturnType>(object obj, Func<PropertyInfo, bool> condition)
            => InternalProperties<TReturnType>(obj, BaseReflection.HIDDEN_STATIC, condition);

        public static IEnumerable<IPropertyAccessor<object>> HiddenStaticProps(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalProperties(obj, BaseReflection.HIDDEN_STATIC, condition);

        public static IEnumerable<IPropertyAccessor<dynamic>> HiddenStaticPropsDyn(object obj, BindingFlags flags, Func<PropertyInfo, bool> condition)
            => InternalPropertiesDyn(obj, BaseReflection.HIDDEN_STATIC, condition);
        #endregion
    }
}
