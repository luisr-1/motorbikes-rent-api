using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using motorbikes_rent_api.Core.Enums;

namespace motorbikes_rent_api.Core.Model;

public class Dasher
{
    [JsonPropertyName("identificador")] 
    public required string Id { get; set; }

    [JsonPropertyName("nome")] 
    public required string? Name { get; set; }

    [JsonPropertyName("cnpj")] 
    public required string? Cnpj { get; set; }

    [JsonPropertyName("data_nascimento")] 
    public required DateTime BirthDate { get; set; }

    [JsonPropertyName("numero_cnh")] 
    public required string? CnhNumber { get; set; }

    [JsonPropertyName("tipo_cnh")] 
    public required CnhTypeEnum[]? CnhTypes { get; set; }

    [JsonPropertyName("imagem_cnh")] 
    public required byte[]? CnhImage { get; set; }
}