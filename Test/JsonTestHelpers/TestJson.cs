using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Test.JsonTestHelpers
{
    internal static class TestJson
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings;

        static TestJson()
        {
            // Setup json serializer with ordered properties, enums as strings and byte arrays as arrays of bytes instead of base64
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new OrderedContractResolver()
            };
            JsonSerializerSettings.Converters.Add(new StringEnumConverter());
            JsonSerializerSettings.Converters.Add(new JsonByteArrayConverter());
        }

        public static string SerializeForApprovalTests(object input)
        {
            return JsonConvert.SerializeObject(input, Formatting.Indented, JsonSerializerSettings);
        }
    }
}