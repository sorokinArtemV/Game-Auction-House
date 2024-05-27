using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SearchService.Helpers;

public class ExcludeNullPropertiesContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        // Exclude properties with null values
        property.ShouldSerialize = instance =>
        {
            var propValue = member is PropertyInfo propInfo
                ? propInfo.GetValue(instance)
                : null;

            return propValue != null;
        };

        return property;
    }
}