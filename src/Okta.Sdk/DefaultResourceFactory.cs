﻿using Okta.Sdk.Abstractions;
using System;
using System.Linq;
using System.Reflection;

namespace Okta.Sdk
{
    public sealed class DefaultResourceFactory : IResourceFactory
    {
        public ChangeTrackingDictionary NewDictionary()
            => new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase);

        public T Create<T>(IDeltaDictionary<string, object> data)
        {
            var ctor = GetConstructor<T>();
            var model = ctor.Invoke(new object[] { data });
            return (T)model;
        }

        private static ConstructorInfo GetConstructor<T>()
        {
            var compatibleCtor = typeof(T).GetTypeInfo()
                .DeclaredConstructors
                .Where(c => c.GetParameters().Length == 1
                         && c.GetParameters()[0].ParameterType == typeof(IDeltaDictionary<string, object>))
                .SingleOrDefault();

            if (compatibleCtor == null) throw new MissingMethodException(
                $"The resource type {typeof(T).FullName} must have a public constructor that accepts IDeltaDictionary<string, object>");

            return compatibleCtor;
        }

    }
}
