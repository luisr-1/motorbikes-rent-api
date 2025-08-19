using motorbikes_rent_api.Core.Entities;
using motorbikes_rent_api.Core.Enums;
using motorbikes_rent_api.Core.Model;

namespace motorbikes_rent_api.Core.Mappers;

public static class DasherMapper
{
    public static DasherEntity ToEntity(this Dasher model)
    {
        return new DasherEntity
        {
            Id = model.Id,
            Name = model.Name,
            Cnpj = model.Cnpj,
            BirthDate = model.BirthDate,
            CnhNumber = model.CnhNumber,
            CnhTypes = model.CnhTypes,
            CnhImageUrl = null
        };
    }

    public static Dasher ToModel(this DasherEntity entity)
    {
        return new Dasher
        {
            Id = entity.Id,
            Name = entity.Name,
            Cnpj = entity.Cnpj,
            BirthDate = entity.BirthDate,
            CnhNumber = entity.CnhNumber,
            CnhTypes = entity.CnhTypes,
            CnhImage = null
        };
    }
}