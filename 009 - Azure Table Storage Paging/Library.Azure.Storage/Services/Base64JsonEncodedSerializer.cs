using System;
using System.Text;
using Newtonsoft.Json;

namespace Library.Azure.Storage.Services
{
    /// <summary>
    /// Serializes and deserializes an object using a combination of base64- and JSON-encoding
    /// </summary>
    public static class Base64JsonEncodedSerializer
    {
        /// <summary>
        /// Deserializes an encoded value
        /// The expected format of serialized value is base64Encode(jsonEncode({object}))
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="value">The serialized object to deserialize</param>
        /// <returns>The deserialized object</returns>
        public static T Deserialize<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            var jsonString = Encoding.UTF8.GetString(Convert.FromBase64String(value));

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// Serializes an object to a base64- and JSON-encoded string
        /// </summary>
        /// <typeparam name="T">The type to serialize</typeparam>
        /// <param name="value">The object to serialize</param>
        /// <returns>The serialized object</returns>
        public static string Serialize<T>(T value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }
    }
}
