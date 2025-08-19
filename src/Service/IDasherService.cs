using motorbikes_rent_api.Core.Mappers;
using motorbikes_rent_api.Core.Model;
using motorbikes_rent_api.Core.Repositories.Interfaces;

namespace motorbikes_rent_api.Service;

public interface IDasherService
{
    Dasher? CreateDasher(Dasher dasher);
}

public class DasherService : IDasherService
{
    private readonly IDasherRepository _dasherRepository;

    public DasherService(IDasherRepository dasherRepository)
    {
        _dasherRepository = dasherRepository;
    }

    public Dasher? CreateDasher(Dasher dasher)
    {
        ArgumentNullException.ThrowIfNull(dasher);
        if (_dasherRepository.GetByIdAsync(dasher.Id).Result != null) throw new Exception("User already registered");
        try
        {
            var createdDasher = _dasherRepository.CreateAsync(dasher.ToEntity()).Result;
            return createdDasher.ToModel();
        }
        catch (Exception e)
        {
            throw new Exception("Unable to create dasher.", e);
        }
    }
}