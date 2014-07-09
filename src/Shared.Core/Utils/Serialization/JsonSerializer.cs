﻿using Newtonsoft.Json;
using Shared.Core.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using Shared.Core.Extensions.Basic;

namespace Shared.Core.Utils.Serialization
{
    public static class JsonSerializer
    {
        public static bool TryDeserializeObject<T>(string json, out T result, CultureInfo culture = null)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture ?? Thread.CurrentThread.CurrentUICulture };
            Newtonsoft.Json.JsonSerializer jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings);

            if (json == null)
            {
                result = ObjectExtensions.GetDefault<T>();
                return false;
            }

            result = (T)Newtonsoft.Json.Linq.JToken.Parse("'" + json + "'").ToObject(typeof(T), jsonSerializer);
            return true;
        }

        public static object DeserializeObject(string json, Type type, CultureInfo culture = null)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture ?? Thread.CurrentThread.CurrentUICulture };
            Newtonsoft.Json.JsonSerializer jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings);

            return json != null ?
                Newtonsoft.Json.Linq.JToken.Parse("'" + json + "'").ToObject(type, jsonSerializer)
                : ObjectExtensions.GetDefault(type);
        }

        public static string Serialize(object obj, CultureInfo culture = null)
        {
            if (obj == null)
                return null;

            var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture ?? Thread.CurrentThread.CurrentUICulture };
            var result = JsonConvert.SerializeObject(obj, jsonSerializerSettings.Formatting, (JsonConverter)DateTimeJsonConverter.Get());

            if (obj is DateTime)
            {
                result = string.Format("new Date('{0}')", obj);
            }
            return result;
        }

        public static T Deserialize<T>(string json, CultureInfo culture = null)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture ?? Thread.CurrentThread.CurrentUICulture };
            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
        }
    }
}