using motorbikes_rent_api.Core.Entities;

namespace motorbikes_rent_api.Core.Repositories.Interfaces;

using Model;

public interface IDasherRepository
{
    Task<DasherEntity?> CreateAsync(DasherEntity? dasher);
    Task<IEnumerable<Dasher?>> GetAllAsync();
    Task<DasherEntity?> GetByIdAsync(string id);
}