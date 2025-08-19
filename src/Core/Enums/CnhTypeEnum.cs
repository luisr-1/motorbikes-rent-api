using System.ComponentModel;
using System.Text.Json.Serialization;

namespace motorbikes_rent_api.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<CnhTypeEnum>))]
public enum CnhTypeEnum
{
    A,
    B
}