using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AmazonStartUp.Infrastructure
{
    /// <summary>
    /// Converts objects to string JSON representation and back.
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Converts an object to a JSON representation.
        /// </summary>
        /// <param name="session">Session to store the JSON representation in.</param>
        /// <param name="key">Key of the JSON representation to store.</param>
        /// <param name="value">Any object to to convert to JSON.</param>
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// Converts a JSON string representation back to an object of type T.
        /// </summary>
        /// <typeparam name="T"> Type of Object to create.</typeparam>
        /// <param name="session">Session to retrieve a JSON representation from.</param>
        /// <param name="key">Key of the JSON representation to get.</param>
        /// <returns>Object of Type T from the JSON representation if exists. Else, a default object of Type T.</returns>
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData is null ? default : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
