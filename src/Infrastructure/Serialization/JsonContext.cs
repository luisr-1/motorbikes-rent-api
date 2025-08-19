using System.Text.Json.Serialization;
using motorbikes_rent_api.Core.Enums;
using motorbikes_rent_api.Core.Model;

namespace motorbikes_rent_api.Infrastructure.Serialization;

[JsonSerializable(typeof(Dasher))]
[JsonSerializable(typeof(CnhTypeEnum))]
public partial class ApiJsonContext : JsonSerializerContext
{
}