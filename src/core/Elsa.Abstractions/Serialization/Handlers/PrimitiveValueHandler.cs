﻿using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Elsa.Serialization.Extensions;

namespace Elsa.Serialization.Handlers
{
    public abstract class PrimitiveValueHandler<T> : IValueHandler
    {
        public virtual int Priority => 0;
        public bool CanSerialize(JToken token, Type type, object value) => type == typeof(T);
        public bool CanDeserialize(JToken token) => token.Type == JTokenType.Object && token.GetValue<string>("Type") == TypeName;
        protected virtual string TypeName => typeof(T).Name;

        public virtual object Deserialize(JsonSerializer serializer, JToken token)
        {
            var valueToken = token["Value"];

            return valueToken == null ? null! : ParseValue(valueToken);
        }

        public virtual void Serialize(JsonWriter writer, JsonSerializer serializer, Type type, JToken token, object? value)
        {
            var objectToken = new JObject
            {
                ["Type"] = TypeName,
                ["Value"] = token
            };
            objectToken.WriteTo(writer, serializer.Converters.ToArray());
        }

        protected abstract object ParseValue(JToken value);
    }
}