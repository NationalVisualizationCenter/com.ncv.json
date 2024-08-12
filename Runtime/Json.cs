using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NCV.Base
{
    public static class Json
    {
        private static JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,

            IgnoreReadOnlyProperties = true,
            IgnoreReadOnlyFields = true,
            IncludeFields = true,

            PropertyNameCaseInsensitive = false,

            ReadCommentHandling = JsonCommentHandling.Disallow,

            WriteIndented = false,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,

            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, options);
        }
        public static T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data, options);
        }
    }

}
