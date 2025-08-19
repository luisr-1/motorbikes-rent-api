using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using motorbikes_rent_api.Core.Enums;

namespace motorbikes_rent_api.Core.Entities;

[Table("dashers")]
public class DasherEntity
{
    [Key] public string Id { get; set; }
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public DateTime BirthDate { get; set; }
    public string? CnhNumber { get; set; }
    public CnhTypeEnum[]? CnhTypes { get; set; }
    public required byte[]? CnhImage { get; set; }
}