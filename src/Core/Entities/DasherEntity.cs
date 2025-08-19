using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using motorbikes_rent_api.Core.Enums;

namespace motorbikes_rent_api.Core.Entities;

[Table("dashers")]
[Index(nameof(Id), IsUnique = true)]
[Index(nameof(Cnpj), IsUnique = true)]
[Index(nameof(CnhNumber), IsUnique = true)]
public class DasherEntity
{
    [Key] public string Id { get; set; }
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public DateTime BirthDate { get; set; }
    public string? CnhNumber { get; set; }
    public CnhTypeEnum[]? CnhTypes { get; set; }
    public required string? CnhImageUrl { get; set; }
}