using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Test.JsonTestHelpers
{
    /// <summary>
    /// Make sure the properties are resolved in alphabetical order.
    /// Source from: https://gist.github.com/akunzai/8313166
    /// </summary>
    internal sealed class OrderedContractResolver : DefaultContractResolver
    {
        protected override System.Collections.Generic.IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).OrderBy(p => p.PropertyName).ToList();
        }
    }
}