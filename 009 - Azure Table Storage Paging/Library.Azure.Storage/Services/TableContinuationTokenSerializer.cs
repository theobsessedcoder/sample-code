using Microsoft.WindowsAzure.Storage.Table;

namespace Library.Azure.Storage.Services
{
    /// <summary>
    /// Serializes and deserializes an Azure table continuation token
    /// </summary>
    public class TableContinuationTokenSerializer
    {
        /// <summary>
        /// Deserializes an encoded continuation token
        /// </summary>
        /// <param name="value">The serialized token</param>
        /// <returns>The deserialized continuation token</returns>
        public static TableContinuationToken Deserialize(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return Base64JsonEncodedSerializer.Deserialize<TableContinuationToken>(value);
        }

        /// <summary>
        /// Serializes a continuation token
        /// </summary>
        /// <param name="continuationToken">The continuation token to serialize</param>
        /// <returns>The serialized token</returns>
        public static string Serialize(TableContinuationToken continuationToken)
        {
            if (continuationToken == null)
            {
                return null;
            }

            return Base64JsonEncodedSerializer.Serialize(continuationToken);
        }
    }
}
