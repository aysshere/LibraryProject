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
        
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key); // This retrieves the JSON string from the session
            if (value != null)
            {
                Console.WriteLine($"JSON being deserialized: {value}"); // This will print out the JSON
            }
            return value == null ? default : JsonSerializer.Deserialize<T>(value); // This is where the error occurs
        }
    }
}
