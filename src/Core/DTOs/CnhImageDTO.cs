using System.Text.Json.Serialization;

namespace motorbikes_rent_api.Core.DTOs;

public class CnhImageDto
{
    [JsonPropertyName("imagem_cnh")] public required string CnhImage { get; set; }
}