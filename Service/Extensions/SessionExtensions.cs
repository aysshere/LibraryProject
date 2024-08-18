using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Service.Extensions
{
    public static class SessionExtensions
    {
        private static readonly JsonSerializerOptions _defaultSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public static void SetJson<T>(this ISession session, string key, T value, JsonSerializerOptions options = null)
        {
            var jsonOptions = options ?? _defaultSerializerOptions;
            session.SetString(key, JsonSerializer.Serialize(value, jsonOptions));
        }

        public static T? GetJson<T>(this ISession session, string key, JsonSerializerOptions options = null)
        {
            var jsonOptions = options ?? _defaultSerializerOptions;
            var value = session.GetString(key);
            if (value == null)
            {
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(value, jsonOptions);
            }
            catch (JsonException ex)
            {
                // Log the exception or handle it as necessary
                // For now, we'll just return the default value.
                return default;
            }
        }
    }
}
